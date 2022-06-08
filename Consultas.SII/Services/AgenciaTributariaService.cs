using Consultas.SII.Contracts;
using Consultas.SII.Entities.Request;
using Consultas.SII.Entities.Response;

using Gesisa.Apps.Common;
using Gesisa.Apps.Common.Extensions;
using Gesisa.Apps.Common.Utilities;

using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Consultas.SII.Services
{

    public partial class AgenciaTributariaService : IAgenciaTributariaService
    {
        /// <inheritdoc/>
        public async Task<Result<AgenciaTributariaResponse>> SendXmlRequestAsync(string agency, string invoiceType, string xmlRequestFilePath)
        {
            // get the endpoint of the agency
            var endpoint = await _soapEndPointResolver.ResolveAsync(agency, invoiceType);
            if (!endpoint.IsValid())
            {
                var result = Result.Failed<AgenciaTributariaResponse>(
                    message: $"there is no soap endpoint defined for agency: {agency} [invoiceType: {invoiceType}]",
                    code: ResultCode.MissingAgencySoapEndpoint);

                _logger.LogError(
                    "failed to send xml request {@info}", new
                    {
                        result.Code,
                        result.Message,
                        agency,
                        invoiceType,
                        xmlRequestFilePath
                    });

                return result;
            }

            // start the process, and return the result
            return await ProcessRequestAsync(xmlRequestFilePath, endpoint);
        }
    }

    public partial class AgenciaTributariaService
    {
        private readonly IFileService _fileService;
        private readonly IApplicationSettingsAccessor _appSettings;
        private readonly ILogger<AgenciaTributariaService> _logger;
        private readonly IAgencySoapEndPointResolver _soapEndPointResolver;

        public AgenciaTributariaService(
            IFileService fileService,
            ILogger<AgenciaTributariaService> logger,
            IAgencySoapEndPointResolver agencySoapEndPointResolver,
            IApplicationSettingsAccessor applicationSettingsAccessor)
        {
            _logger = logger;
            _fileService = fileService;
            _appSettings = applicationSettingsAccessor;
            _soapEndPointResolver = agencySoapEndPointResolver;
        }

        private Task<Result<AgenciaTributariaResponse>> ProcessRequestAsync(string xmlRequestFilePath, string endpoint)
            => Task.FromResult(ProcessRequest(xmlRequestFilePath, endpoint));

        private Result<AgenciaTributariaResponse> ProcessRequest(string xmlRequestFilePath, string endpoint)
        {
            //if (_appSettings.GetEnvironmentType() == EnvironmentType.Development)
            //{
            //    _logger.LogInformation("returning fake result in development mode");

            //    //return Result.FakeFailure<AgenciaTributariaResponse>();
            //    return new AgenciaTributariaResponse
            //    {
            //        ResponseXmlFilePath = _appSettings.GetTestXmlResponseFilePath(),
            //    };
            //}

            // build the curl arguments
            var xmlRequestFileName = Path.GetFileName(xmlRequestFilePath);
            var fileName = _fileService.GenerateXmlResponseFileName(xmlRequestFileName);
            var outputFilePath = _fileService.GetXmlResponseOutputDirectoryPath(fileName);
            var curlArgs = BuildCurlArgs(endpoint, xmlRequestFilePath, outputFilePath);

            // get the path to the Curl Executable
            var curlProgramPath = _appSettings.GetCurlProgramPath();
            if (!File.Exists(curlProgramPath))
            {
                var result = Result.Failed<AgenciaTributariaResponse>(
                    message: "the curlProgram executable not exist",
                    code: ResultCode.CurlExecutableMissing);

                _logger.LogError("failed to send xml request {@info}", new
                    {
                        result.Code,
                        result.Message,
                        CurlProgramPath = curlProgramPath
                    });

                return result;
            }

            // execute the curl command
            var executionResult = ExecuteCommand(curlProgramPath, curlArgs);
            if (!executionResult.IsSuccess())
                return Result.From<AgenciaTributariaResponse>(executionResult);

            // return result
            return new AgenciaTributariaResponse
            {
                ResponseXmlFilePath = outputFilePath
            };
        }

        private Result ExecuteCommand(string curlProgramPath, string curlArgs)
        {
            try
            {
                using var process = new System.Diagnostics.Process()
                {
                    StartInfo = new System.Diagnostics.ProcessStartInfo(curlProgramPath, curlArgs)
                    {
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };

                process.Start();

                using (StreamReader streamReader = process.StandardError)
                {
                    var output = streamReader.ReadToEnd();
                    if (output.IsValid())
                    {
                        var result = Result.Failed(
                            message: output,
                            code: ResultCode.CurlExecutionFailed);

                        _logger.LogError("failed to send xml request {@info}", new
                           {
                               result.Code,
                               result.Message,
                               CurlArgs = curlArgs,
                               CurlProgramPath = curlProgramPath
                           });

                        return result;
                    }
                }

                return Result.Success();
            }
            catch (System.Exception ex)
            {
                var result = Result.Failed(
                    message: "failed to execute the Curl command",
                    code: ResultCode.CurlExecutionFailed,
                    exception: ex);

                _logger.LogError(ex,
                    "failed to send xml request {@info}", new
                    {
                        result.Code,
                        result.Message,
                        CurlArgs = curlArgs,
                        CurlProgramPath = curlProgramPath
                    });

                return result;
            }
        }

        private string BuildCurlArgs(string endpoint, string requestFilePath, string outputFilePath)
        {
            var commanTimeOut = _appSettings.GetCurlCommandTimeOut();
            var connectionTimeOut = _appSettings.GetCurlConnectionTimeOut();
            var (certificate, certificateKey) = _appSettings.GetAgenciaTributariaCerticate();

            return $@"--connect-timeout {connectionTimeOut} -m {commanTimeOut} -s -S -L --cert ""{certificate}"" --key ""{certificateKey}"" --data ""@{requestFilePath}""  -H ""Content-Type: application/xml; charset=utf-8"" --output ""{outputFilePath}"" ""{endpoint}""";
        }
    }

    public partial class FileService
    {
        /// <inheritdoc/>
        public string GetTempFilePath(ProcessFileQueueRequest model)
        {
            // build the path
            var path = _pathBuilder.Build(
                pathTemplate: _appSettings.GetTempFileOutPutsDirectory(),
                args: new[]
                {
                    new KeyValuePair<string, string>(key: "fileName", value: model.FileName),
                    new KeyValuePair<string, string>(key: "identifier", value: model.Identifier),
                });

            // ensure path is created
            FileHelper.EnsureDirectory(path);

            // return the path
            return path;
        }

        /// <inheritdoc/>
        public string GenerateXmlResponseFileName(string xmlRequestFileName)
            => xmlRequestFileName.Replace("Enviado", "Respuesta");

        /// <inheritdoc/>
        public string GenerateXmlRequestFileName(ProcessFileQueueRequest model)
            => $"{GetDocumentType(model.FileMetaData.DocumentType)}_{model.AgencyId}_{DateTime.Now:yyyyMMdd_HHmmssfff}.xml";
        /// <inheritdoc/>
        public string GenerateXmlRequestFileName(ProcessFileQueueRequest model, string additionalInfo)
            => $"{GetDocumentType(model.FileMetaData.DocumentType)}_{model.AgencyId}_{DateTime.Now:yyyyMMdd_HHmmssfff}_{additionalInfo}.xml";

        /// <inheritdoc/>
        public string GenerateChunkXmlRequestFileName(ProcessFileQueueRequest model, int chunkStart, int chunkEnd)
            => $"{GetDocumentType(model.FileMetaData.DocumentType)}_{model.AgencyId}_Chunk_{chunkStart}_{chunkEnd}_{DateTime.Now:yyyyMMdd_HHmmssfff}.xml";

        /// <inheritdoc/>
        public string GenerateChunkXmlRequestFileName(ProcessFileQueueRequest model, int chunkStart, int chunkEnd, string additionalInfo)
            => $"{GetDocumentType(model.FileMetaData.DocumentType)}_{model.AgencyId}_Chunk_{chunkStart}_{chunkEnd}_{DateTime.Now:yyyyMMdd_HHmmssfff}_{additionalInfo}.xml";

        /// <inheritdoc/>
        public string GetXmlResponseOutputDirectoryPath(string fileName)
        {
            // build the path
            var path = _pathBuilder.Build(
                pathTemplate: _appSettings.GetXmlResponseDirectory(),
                args: new[]
                {
                    new KeyValuePair<string, string>(key: "identifier", value: "nouser"),
                    new KeyValuePair<string, string>(key: "fileName", fileName),
                });

            // ensure path is created
            FileHelper.EnsureDirectory(path);

            // return the path
            return path;
        }

        /// <inheritdoc/>
        public string MoveCsvFileFromTempDirectory(string tempFilePath)
        {
            // get the file name
            var fileName = Path.GetFileName(tempFilePath);

            // build the path
            var filePath = buildPath(fileName);

            // check if the file exist
            if (File.Exists(filePath))
            {
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                var fileExtention = Path.GetExtension(fileName).ToLower();

                var countFilesWithSameName = Directory.EnumerateFiles(
                    path: Path.GetDirectoryName(filePath),
                    searchPattern: $"{fileNameWithoutExtension}*")
                .Count();

                fileName = $"{fileNameWithoutExtension}_Copy ({countFilesWithSameName}){fileExtention}";
                filePath = buildPath(fileName);
            }

            // ensure path is created
            FileHelper.EnsureDirectory(filePath);

            // move the file to new location
            File.Move(tempFilePath, filePath);

            // return the new path of the file
            return filePath;

            string buildPath(string fileName)
            {
                return _pathBuilder.Build(
                    pathTemplate: _appSettings.GetCsvFilesOutputDirectory(),
                    args: new[]
                    {
                        new KeyValuePair<string, string>(key: "fileName", value: fileName),
                        new KeyValuePair<string, string>(key: "identifier", value: "nouser"),
                    });
            }
        }

        /// <inheritdoc/>
        public string MoveXmlFileFromTempDirectory(string tempFilePath)
        {
            // get the file name
            var fileName = Path.GetFileName(tempFilePath);

            // build the path
            var filePath = buildPath(fileName);

            // check if the file exist
            if (File.Exists(filePath))
            {
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                var fileExtention = Path.GetExtension(fileName).ToLower();

                var countFilesWithSameName = Directory.EnumerateFiles(
                    path: Path.GetDirectoryName(filePath),
                    searchPattern: $"{fileNameWithoutExtension}*")
                .Count();

                fileName = $"{fileNameWithoutExtension}_Copy ({countFilesWithSameName}){fileExtention}";
                filePath = buildPath(fileName);
            }

            // ensure path is created
            FileHelper.EnsureDirectory(filePath);

            // move the file to new location
            File.Move(tempFilePath, filePath);

            // return the new path of the file
            return filePath;

            string buildPath(string fileName)
            {
                return _pathBuilder.Build(
                    pathTemplate: _appSettings.GetXmlRequestDirectory(),
                    args: new[]
                    {
                        new KeyValuePair<string, string>(key: "fileName", value: fileName),
                        new KeyValuePair<string, string>(key: "identifier", value: "nouser"),
                    });
            }
        }

        /// <inheritdoc/>
        public string SaveXmlRequestDocument(string fileName, XmlDocument xmlRequest)
        {
            // build the path
            var path = _pathBuilder.Build(
                pathTemplate: _appSettings.GetXmlRequestDirectory(),
                args: new[]
                {
                    new KeyValuePair<string, string>(key: "identifier", value: "nouser"),
                    new KeyValuePair<string, string>(key: "fileName", value: fileName),
                });

            // ensure path is created
            FileHelper.EnsureDirectory(path);

            // save the xml document
            using (var writer = XmlWriter.Create(path, _xmlSavingSettings))
            {
                xmlRequest.Save(writer);
            }

            // return the file path
            return path;
        }

        /// <inheritdoc/>
        public string GetCsvFileLocation(string fileName)
        {
            return _pathBuilder.Build(
                pathTemplate: _appSettings.GetCsvFilesOutputDirectory(),
                args: new[]
                {
                    new KeyValuePair<string, string>(key: "fileName", value: fileName),
                    new KeyValuePair<string, string>(key: "identifier", value: "nouser"),
                });
        }
    }

    public partial class FileService : IFileService
    {
        private readonly XmlWriterSettings _xmlSavingSettings;

        private readonly IPathBuilder _pathBuilder;
        private readonly IApplicationSettingsAccessor _appSettings;

        public FileService(
            IPathBuilder pathBuilder,
            IApplicationSettingsAccessor applicationSettingsAccessor)
        {
            _pathBuilder = pathBuilder;
            _appSettings = applicationSettingsAccessor;

            _xmlSavingSettings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = new UTF8Encoding(false),
            };
        }

        private static string GetDocumentType(string documentType)
        {
            return documentType switch
            {
                SiiRequestType.Type_FE => $"Enviado_Emitidas",
                SiiRequestType.Type_FA => $"Enviado_Alquiler",
                SiiRequestType.Type_FR => $"Enviado_Recibidas",
                SiiRequestType.Type_BE => $"Baja_Emitida",
                SiiRequestType.Type_BR => $"Baja_Recibida",
                SiiRequestType.Type_CO => $"Enviado_Cobros",
                SiiRequestType.Type_PA => $"Enviado_Pagos",
                _ => $"Enviado",
            };
        }
    }
    public static class SiiRequestType
    {
        public const string Type_FA = "FA";
        public const string Type_FE = "FE";
        public const string Type_FR = "FR";
        public const string Type_BE = "BE";
        public const string Type_BR = "BR";
        public const string Type_CO = "CO";
        public const string Type_PA = "PA";
    }
}
