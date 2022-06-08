using Consultas.SII.Entities.Response;

using Gesisa.Apps.Common;
using Gesisa.Apps.Common.Enums;
using Gesisa.Apps.Common.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultas.SII.Contracts
{

    /// <summary>
    /// the application secrets accessor service
    /// </summary>
    public interface IApplicationSecretsAccessor
    {
    }
    /// <summary>
    /// the Resolver to resolve the Soap Endpoint base on the agency and invoiceType
    /// </summary>
    public interface IAgencySoapEndPointResolver
    {
        /// <summary>
        /// resolve the soap endpoint base on the given agency and invoiceType
        /// </summary>
        /// <param name="agency">the agency identifier</param>
        /// <param name="invoiceType">the type of the invoice</param>
        /// <returns>the soap endpoint</returns>
        Task<string> ResolveAsync(string agency, string invoiceType);
    }
    //
    // Summary:
    //     the base Application settings accessor
    public interface IApplicationSettingsAccessorBase
    {
        //
        // Summary:
        //     get the name of the application
        string ApplicationName { get; }

        //
        // Summary:
        //     get the email Settings
        //
        // Returns:
        //     the email settings
        EmailSettings GetEmailSettings();
        //
        // Summary:
        //     get the Environment Type
        //
        // Returns:
        //     the Gesisa.Apps.Common.Enums.EnvironmentType
        EnvironmentType GetEnvironmentType();
        //
        // Summary:
        //     get the URL value
        //
        // Parameters:
        //   pathName:
        //     the name of the URL to retrieve
        string GetUrl(string pathName);
    }
    /// <summary>
    /// the application configuration accessor
    /// </summary>
    public interface IApplicationSettingsAccessor : IApplicationSettingsAccessorBase
    {
        /// <summary>
        /// Get the path to where to save the CSV files
        /// </summary>
        /// <returns></returns>
        string GetCsvFilesOutputDirectory();

        /// <summary>
        /// Get the path to where to save th files temporarily
        /// </summary>
        /// <returns></returns>
        string GetTempFileOutPutsDirectory();

        /// <summary>
        /// Get the path to where to save the XML request files
        /// </summary>
        /// <returns></returns>
        string GetXmlRequestDirectory();

        /// <summary>
        /// Get the path to where to save the XML Response files
        /// </summary>
        /// <returns></returns>
        string GetXmlResponseDirectory();

        /// <summary>
        /// get the max number of records to be processed at a time
        /// </summary>
        /// <returns></returns>
        int GetMaxAllowedRecordsCount();

        /// <summary>
        /// get the time out value for the Curl command
        /// </summary>
        /// <returns></returns>
        int GetCurlCommandTimeOut();

        /// <summary>
        /// get the Connection time out of the curl command
        /// </summary>
        /// <returns></returns>
        int GetCurlConnectionTimeOut();

        /// <summary>
        /// get the path to the Certificate
        /// </summary>
        /// <returns></returns>
        (string certificate, string certificateKey) GetAgenciaTributariaCerticate();

        /// <summary>
        /// get the path to the location of the Curl Program executable
        /// </summary>
        /// <returns></returns>
        string GetCurlProgramPath();

        /// <summary>
        /// get the path to the Xml Response file for test purpose
        /// </summary>
        /// <returns></returns>
        string GetTestXmlResponseFilePath();

        /// <summary>
        /// Gets the number of days for password expiration
        /// </summary>
        /// <returns>int</returns>
        int GetPasswordExpirationDays();
    }
    public interface IAgenciaTributariaService
    {
        /// <summary>
        /// send the Xml Request for the given agency with the given invoice type
        /// </summary>
        /// <param name="userId">the id of the user this request associated with it</param>
        /// <param name="agency">the agency name</param>
        /// <param name="invoiceType">the invoice type</param>
        /// <param name="xmlRequestFilePath">the xml request file path</param>
        /// <returns></returns>
        Task<Result<AgenciaTributariaResponse>> SendXmlRequestAsync(string agency, string invoiceType, string xmlRequestFilePath);

    }
}
