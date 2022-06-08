using Consultas.SII.Entities;
using Consultas.SII.Entities.Request;

using Gesisa.Apps.Common;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Consultas.SII.Contracts
{

    /// <summary>
    /// repository for accessing the CommunicationUrls for the agencies
    /// </summary>
    public interface IAgencyCommunicationUrlRepository
    {
        /// <summary>
        /// get the Communication URL information for the given agency
        /// </summary>
        /// <param name="agency">the agency to retrieve the communication URL for it</param>
        /// <param name="invoiceType">the invoice type associated with the request</param>
        /// <returns>instant of <see cref="AgencyCommunicationUrl"/></returns>
        Task<AgencyCommunicationUrl> GetAgencyCommunicationUrlAsync(string agency, string invoiceType);
    }
    /// <summary>
    /// service for handing file interaction operations
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// get the location to where to save the file temporally
        /// </summary>
        /// <param name="model">the file queue model</param>
        /// <returns>the path location</returns>
        string GetTempFilePath(ProcessFileQueueRequest model);

        /// <summary>
        /// generate a name for the xml response file
        /// </summary>
        /// <param name="xmlRequestFileName">the xml request file path</param>
        /// <returns>the generated file name</returns>
        string GenerateXmlResponseFileName(string xmlRequestFileName);

        /// <summary>
        /// generate a name for the xml request file
        /// </summary>
        /// <param name="model">the file queue instant</param>
        /// <returns>the generated file name</returns>
        string GenerateXmlRequestFileName(ProcessFileQueueRequest model);

        /// <summary>
        /// generate a name for the file queue chunk xml request file
        /// </summary>
        /// <param name="userId">the id of the user</param>
        /// <param name="model">the file queue instant</param>
        /// <param name="chunkStart">the file queue chunk starting point</param>
        /// <param name="chunkEnd">the file queue chunk ending point</param>
        /// <returns>the generated file name</returns>
        string GenerateChunkXmlRequestFileName(ProcessFileQueueRequest model, int chunkStart, int chunkEnd);

        /// <summary>
        /// get the path to where to save the xml response
        /// </summary>
        /// <param name="userId">the id of the user</param>
        /// <param name="fileName">the name of the xml request file with extension <code>example: XML_RESPONSE_111.xml</code></param>
        /// <returns>the path location</returns>
        string GetXmlResponseOutputDirectoryPath(string fileName);

        /// <summary>
        /// move the CSV file for the temporary location to the user folder
        /// </summary>
        /// <param name="userId">the id of the user</param>
        /// <param name="tempFilePath">the full path to where the file is located</param>
        /// <returns>the new path of the file</returns>
        string MoveCsvFileFromTempDirectory(string tempFilePath);

        /// <summary>
        /// save the xml request content to a file with name: <paramref name="fileName"/>
        /// </summary>
        /// <param name="userId">the id of the user</param>
        /// <param name="fileName">the file name of the xml document <code>example: XML_REQUEST_111.xml</code></param>
        /// <param name="xmlRequest">the xml document content</param>
        /// <returns>the full path to where file is saved</returns>
        string SaveXmlRequestDocument(string fileName, XmlDocument xmlRequest);

        /// <summary>
        /// move the XML file from the Temp directory to the user directory
        /// </summary>
        /// <param name="userId">the id of the user</param>
        /// <param name="tempFilePath">the full path to where the file is located</param>
        /// <returns>the new path to the xml request file</returns>
        string MoveXmlFileFromTempDirectory(string tempFilePath);

        /// <summary>
        /// generate a name for the xml request file
        /// </summary>
        /// <param name="userId">the id of the user</param>
        /// <param name="model">the file queue instant</param>
        /// <param name="additionalInfo">additional string to append to the end of the filename</param>
        /// <returns>the generated file name</returns>
        string GenerateXmlRequestFileName(ProcessFileQueueRequest model, string additionalInfo);

        /// <summary>
        /// generate a name for the file queue chunk xml request file
        /// </summary>
        /// <param name="userId">the id of the user</param>
        /// <param name="model">the file queue instant</param>
        /// <param name="chunkStart">the file queue chunk starting point</param>
        /// <param name="chunkEnd">the file queue chunk ending point</param>
        /// <param name="additionalInfo">additional string to append to the end of the filename</param>
        /// <returns>the generated file name</returns>
        string GenerateChunkXmlRequestFileName(ProcessFileQueueRequest model, int chunkStart, int chunkEnd, string additionalInfo);
    }
    public interface ISiiRepository
    {
        int BajaRegistroInformacionById(int pIdOperacion, int pIdRegistroInformacion);
        int DeleteCobroById(int pId);
        int DeleteCobrosEmitidas(int pIdRegistro);
        int DeleteCobrosEmitidas(int pIdRegistro, IDbConnection connection);
        int DeleteDetalleImportesIva(int idRegistro);
        int DeleteDetalleImportesIva(int idRegistro, IDbConnection connection);
        int DeleteDetalleInmuebleByRegistro(int pIdRegistro);
        int DeleteDetalleInmuebleByRegistro(int pIdRegistro, IDbConnection connection);
        int DeleteFacturasAgrupadas(int idRegistroInformacion);
        int DeleteFacturasAgrupadas(int idRegistroInformacion, IDbConnection connection);
        int DeleteFacturasRectificadas(int idRegistroInformacion);
        int DeleteFacturasRectificadas(int idRegistroInformacion, IDbConnection connection);
        int DeletePagoById(int pId);
        int DeletePagosRecibidas(int pIdRegistro);
        int DeletePagosRecibidas(int pIdRegistro, IDbConnection connection);
        List<ECausaExencion> GetCausaExencion(string IdAgencia);
        List<EClaveRegimen> GetClaveRegimenBy(string pIdLibroRegistro, string IdAgencia);
        List<EClaveRegimen> GetClaveRegimenBy(string pIdLibroRegistro, string IdAgencia, IDbConnection connection);
        List<ECobro> GetCobrosEmitidas(int pIdRegistroInformacion);
        List<ECobro> GetCobrosEmitidas(int pIdRegistroInformacion, IDbConnection connection);
        EDatosDescuadreContraparte GetDatosDescuadreContraparte(int pIdRegistroInformacion);
        EDatosDescuadreContraparte GetDatosDescuadreContraparte(int pIdRegistroInformacion, IDbConnection connection);
        List<EDetalleImportesIVA> GetDetalleImportesIva(int pIdRegistroInformacion);
        List<EDetalleImportesIVA> GetDetalleImportesIva(int pIdRegistroInformacion, IDbConnection connection);
        List<EDetalleInmueble> GetDetalleInmuebleByRegistro(int IdRegistroInformacion);
        List<EDetalleInmueble> GetDetalleInmuebleByRegistro(int IdRegistroInformacion, IDbConnection connection);
        List<EFacturasAgrupadas> GetFacturasAgrupadas(int pIdRegistroInformacion);
        List<EFacturasAgrupadas> GetFacturasAgrupadas(int pIdRegistroInformacion, IDbConnection connection);
        List<EFacturasRectificadas> GetFacturasRectificadas(int pIdRegistroInformacion);
        List<EFacturasRectificadas> GetFacturasRectificadas(int pIdRegistroInformacion, IDbConnection connection);
        List<EPaisResidencia> GetIdType(string IdAgencia);
        List<EPago> GetPagosRecibidas(int pIdRegistroInformacion);
        List<EPago> GetPagosRecibidas(int pIdRegistroInformacion, IDbConnection connection);
        List<EPeriodo> GetPeriodosByTipoPresentacion(string pTipoPresentacion);
        List<EPeriodo> GetPeriodosByTipoPresentacion(string pTipoPresentacion, IDbConnection connection);
        ERegistroInformacion GetRegistroInformacionByEjercioNifSerie(DateTime FechaExpedicionFacturaEmisor, string NifFacturaEmisor, string IDFactura, string NumSerieFacturaEmisor, string idAgencia);
        ERegistroInformacion_IGIC GetRegistroInformacion_IGIC_ById(int pIdRegistroInformacion);
        List<ETipoBienOperacion> GetTipoBienOperacion();
        List<ETipoDocumentoArt25> GetTipoDocumentoArt25();
        List<ETipoFactura> GetTipoFactura(string IdAgencia);
        List<ETipoFactura> GetTipoFactura(string IdAgencia, IDbConnection connection);
        int HideRegistroInformacion(string NifFacturaEmisor, string IdFactura, string NumSerieFacturaEmisor, DateTime? FechaExpedicionFacturaEmisor);
        int InsertDetalleInmueble(EDetalleInmueble vDetalleInmueble);
        int InsertDetalleInmueble(EDetalleInmueble vDetalleInmueble, IDbConnection connection);
        int InsertUpdateCobros(ECobro vCobro);
        string InsertUpdateDatosComplementarios(EDatosComplementarios vDatosComplementarios);
        int InsertUpdateDatosComplementarios(EDatosComplementarios vDatosComplementarios, IDbConnection connection);
        int InsertUpdateDatosDescuadreCotraparte(int pIdRegistroInformacion);
        int InsertUpdateDatosDescuadreCotraparte(int pIdRegistroInformacion, IDbConnection connection);
        int InsertUpdateDetalleImportesIVA(EDetalleImportesIVA vDetalleImportesIVA);
        int InsertUpdateDetalleImportesIVA(EDetalleImportesIVA vDetalleImportesIVA, IDbConnection connection);
        int InsertUpdatePagos(EPago vPago);
        int InsertUpdatePagos(EPago vPago, IDbConnection connection);
        Result<int> InsertUpdateRegistroInformacion(ERegistroInformacion RegistroInfo, string pIdTipoOperacion, string idAgencia);
        int InsertUpdateRegistroInformacion_IGIC(ERegistroInformacion_IGIC vRegistroInformacion_IGIC);
        int InsertUpdateRegistroInformacion_IGIC(ERegistroInformacion_IGIC vRegistroInformacion_IGIC, IDbConnection connection);
        int InsesrtUpdateFacturasAgrupadas(EFacturasAgrupadas vFacturasAgrupadas);
        int InsesrtUpdateFacturasRectificadas(EFacturasRectificadas vFacturasRectificadas);
    }
}
