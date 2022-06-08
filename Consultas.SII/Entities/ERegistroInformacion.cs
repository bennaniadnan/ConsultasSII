using Consultas.SII.Entities.Enumerator;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Consultas.SII.Entities
{

    /// <summary>
    /// this class defines the agency api communication endpoint
    /// </summary>
    public class AgencyCommunicationUrl
    {
        /// <summary>
        /// the id of the agency Communication URL
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// the agency associated with this URL
        /// </summary>
        public string Agency { get; set; }

        /// <summary>
        /// the document associated with this URL
        /// </summary>
        public string DocumentType { get; set; }

        /// <summary>
        /// the communication URL value
        /// </summary>
        public string Url { get; set; }
    }
    public class EPaisResidencia
    {

        public string Id { get; set; }

        public string Descripcion { get; set; }
    }
    public class ETipoDocumentoArt25
    {

        public string Id { get; set; }

        public string Descripcion { get; set; }
    }
    public class ETipoBienOperacion
    {

        public string Id { get; set; }

        public string Descripcion { get; set; }
    }
    public class ETipoFactura
    {

        public string Id { get; set; }

        public string Descripcion { get; set; }

        public int Orden { get; set; }

        public string IdAgencia { get; set; }
    }
    public class ECausaExencion
    {

        public string CausaExencion { get; set; }

        public string IdAgencia { get; set; }

        public string Descripcion { get; set; }
    }

    public class EClaveRegimen
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
    }
    public class EPeriodo
    {
        public string Id { get; set; }
        public string Texte { get; set; }
        public string TipoPresentacion { get; set; }

    }
    public class AgencyNameSpace
    {
        public string Sii { get; set; }
        public string SiiLR { get; set; }
        public string SiiLRC { get; set; }
        public string SiiLRRC { get; set; }
        public string SiiR { get; set; }
        public string SoapAddressFE { get; set; }
        public string SoapAddressFR { get; set; }
        public string Root { get; set; }
    }
    public partial class ERegistroInformacion
    {
        public int Id { get; set; }

        public string IdLibroRegistro { get; set; }

        public string NifDeclarante { get; set; }

        // *
        public string NumSerieFacturaEmisor { get; set; }

        // *
        public DateTime FechaExpedicionFacturaEmisor { get; set; }

        // *
        public string NifFacturaEmisor { get; set; }

        // *
        public string IDIdFactura { get; set; }

        public string NumSerieFacturaEmisorResumenFin { get; set; }

        public string TipoFactura { get; set; }

        public string NombreRazon { get; set; }

        public string NIFRepresentante { get; set; }

        public string NifContraparte { get; set; }

        public string CodigoPaisContraparte { get; set; }

        public string IDTypeContraparte { get; set; }

        public string IDContraparte { get; set; }

        public string CodigoPaisIdFactura { get; set; }

        public string IDTypeIdFactura { get; set; }


        public decimal? BaseRectificada { get; set; }

        public decimal? CuotaRectificada { get; set; }

        public decimal? CuotaRecargoRectificada { get; set; }

        public string TipoRectificativa { get; set; }

        public DateTime? FechaExpedicionFactura { get; set; }

        public DateTime? FechaOperacion { get; set; }

        public decimal? ImporteTotal { get; set; }

        public string ClaveRegimenEspecialOTrascendencia { get; set; }

        public decimal? BaseImponibleACoste { get; set; }

        public string DescripcionOperacion { get; set; }

        public int? SituacionInmueble { get; set; }

        public string ReferenciaCatastral { get; set; }

        public string CausaExencion { get; set; }

        public decimal? BaseImponible { get; set; }

        public string TipoNoExenta { get; set; }

        public string TipoNoSujeta { get; set; }

        public decimal? ImportePorArticulos7_14_Otros { get; set; }

        public decimal? ImporteTAIReglasLocalizacion { get; set; }

        public decimal? ImporteTransmisionSujetoAIVA { get; set; }

        public string EmitidaPorTerceros { get; set; }

        public string NumeroDUA { get; set; }

        public DateTime? FechaRegContableDUA { get; set; }

        public DateTime? FechaRegContable { get; set; }

        public decimal? CuotaDeducible { get; set; }

        public string TipoOperacion { get; set; }

        public string ClaveDeclarado { get; set; }

        public string EstadoMiembro { get; set; }

        public int? PlazoOperacion { get; set; }

        public string DescripcionBienes { get; set; }

        public string DireccionOperador { get; set; }

        public string FacturasODocumentacion { get; set; }

        public string ProrrataAnualDefinitiva { get; set; }

        public decimal? RegularizacionAnualDeduccion { get; set; }

        public string IdentificacionEntrega { get; set; }

        public decimal? RegularizacionDeduccionEfectuada { get; set; }

        public int? Ejercicio { get; set; }

        public string Periodo { get; set; }

        public DateTime? FechaInicioUtilizacion { get; set; }

        public string IdentificacionBien { get; set; }

        public bool? Baja { get; set; }

        public DateTime? FechaBaja { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EnumEstadoLectura? IdEstadoLectura { get; set; }

        /**/
        public List<EDetalleImportesIVA> ListDetailIva { get; set; }

        /**/
        public List<EFacturasAgrupadas> ListFacturasAgrupadas { get; set; }

        /**/
        public List<EFacturasRectificadas> ListFacturasRectificadas { get; set; }

        public List<ECobro> ListCobros { get; set; }

        public List<EPago> ListPagos { get; set; }

        public string VariosDestinatarios { get; set; }

        public string Cupon { get; set; }

        public string NombreContraparte { get; set; }

        public EnumEstadoRegistro? IdEstadoRegistro { get; set; }

        public int TipoDesglose { get; set; }

        public int DesgloseTipoOperacion { get; set; }

        public EDatosComplementarios DatosComplementarios { get; set; }

        public EnumEstadoCuadre? IdEstadoCuadre { get; set; }

        public EDatosDescuadreContraparte DatosDescuadreContraparte { get; set; }

        // ATC => FE + FR
        public ERegistroInformacion_IGIC RegistroInformacion_IGIC { get; set; }

        public List<EDetalleInmueble> DetalleInmuebles { get; set; } = new List<EDetalleInmueble>();

        public int? CodigoErrorRegistro { get; set; }

        public string DescripcionErrorRegistro { get; set; }
        public DateTime? FechaFinPlazo { get; set; }

        /// <summary>
        /// S: <see cref="PeriodoDeduccion"/> and <see cref="EjercicioDeduccion"/> not null
        /// else N
        /// </summary>
        public string ADeducirEnPeriodoPosterior { get; set; }
        public int? EjercicioDeduccion { get; set; }

        public string PeriodoDeduccion { get; set; }
    }

    public partial class ERegistroInformacion : IEquatable<ERegistroInformacion>
    {
        /// <summary>
        /// check if the given <see cref="ERegistroInformacion"/> by checking if:
        /// <para><see cref="NumSerieFacturaEmisor"/> are equals</para>
        /// <para>and if <see cref="IDIdFactura"/> is valid must be equals</para>
        /// <para>or if <see cref="NifFacturaEmisor"/> is valid must be equals</para>
        /// </summary>
        /// <param name="other">the other instant to check equality with it</param>
        /// <returns>true if equals false if not</returns>
        public bool Equals([AllowNull] ERegistroInformacion other)
        {
            if (other is null)
                return false;

            if (NumSerieFacturaEmisor != other.NumSerieFacturaEmisor ||
                FechaExpedicionFacturaEmisor != other.FechaExpedicionFacturaEmisor)
                return false;

            if (!string.IsNullOrEmpty(NifFacturaEmisor) &&
                !string.IsNullOrEmpty(other.NifFacturaEmisor) &&
                NifFacturaEmisor != other.NifFacturaEmisor)
                return false;

            if (!string.IsNullOrEmpty(IDIdFactura) &&
                !string.IsNullOrEmpty(other.IDIdFactura) &&
                IDIdFactura != other.IDIdFactura)
                return false;

            return true;
        }


    }
    public class EFacturasAgrupadas
    {

        public int? Id { get; set; }

        public int IdRegistroInformacion { get; set; }

        public string NumSerieFacturaEmisor { get; set; }

        public DateTime FechaExpedicionFacturaEmisor { get; set; }

    }

    public class EDatosDescuadreContraparte
    {
        public int IdRegistroInformacion { get; set; }
        public decimal SumBaseImponibleISP { get; set; }
        public decimal SumBaseImponible { get; set; }
        public decimal SumCuota { get; set; }
        public decimal SumCuotaRecargoEquivalencia { get; set; }
        public decimal ImporteTotal { get; set; }
    }
    public class EDetalleInmueble
    {

        public int Id { get; set; }

        public int IdRegistroInformacion { get; set; }

        public int SituacionInmueble { get; set; }

        public string ReferenciaCatastral { get; set; }
    }
    public class ERegistroInformacion_IGIC
    {

        public int IdRegistroInformacion { get; set; }

        public string PagoAnticipado { get; set; }

        public string IdTipoBienOperacion { get; set; }

        public string IdTipoDocumentoArt25 { get; set; }

        public string NumeroProtocolo { get; set; }

        public string NombreNotario { get; set; }
    }
    public class EDatosComplementarios
    {

        public int IdRegistroInformacion { get; set; }

        public string ClaveRegimen1 { get; set; }

        public string ClaveRegimen2 { get; set; }

        public string Autorizacion { get; set; }

        public string RefExterna { get; set; }

        public string SimplificadaArt { get; set; }

        public string NombreSucedida { get; set; }

        public string NifSucedida { get; set; }

        public string RegPrevio { get; set; }

        public string Macrodato { get; set; }

        public string FacturaEnergia { get; set; }

        public string SinDestinatario { get; set; }

        public string NumRegistroAcuerdoFacturacion { get; set; }

        public string FacturacionDispAdicionalTerceraYsexta { get; set; }
    }
    public class EPago
    {

        public int Id { get; set; }

        public int IdRegistroInformacion { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Importe { get; set; }

        public string IdMedio { get; set; }

        public string Cuenta_O_Medio { get; set; }

        public bool Nuevo { get; set; }

        public int? IdEstadoCobroPago { get; set; }
    }
    public class ECobro
    {


        public int Id { get; set; }

        public int IdRegistroInformacion { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Importe { get; set; }

        public string IdMedio { get; set; }

        public string Cuenta_O_Medio { get; set; }

        public bool Nuevo { get; set; }

        public int? IdEstadoCobroPago { get; set; }
    }
    public class EFacturasRectificadas
    {

        public int? Id { get; set; }

        public int IdRegistroInformacion { get; set; }

        public string NumSerieFacturaEmisor { get; set; }

        public DateTime FechaExpedicionFacturaEmisor { get; set; }
    }
    public class EDetalleImportesIVA
    {

        public int? Id { get; set; }

        public int IdRegistro { get; set; }

        public int IdTipoDetalleIVA { get; set; }

        public decimal TipoImpositivo { get; set; }

        public decimal BaseImponible { get; set; }

        public decimal CuotaRepercutida { get; set; }

        public decimal CuotaSoportada { get; set; }

        public decimal? TipoRecargoEquivalencia { get; set; }

        public decimal? CuotaRecargoEquivalencia { get; set; }

        public decimal? ImporteCompensacionREAGYP { get; set; }

        public decimal? PorcentCompensacionREAGYP { get; set; }

        public decimal? CuotaRecargoMinorista { get; set; }

        public decimal? CargaImpositivaImplicita { get; set; }
        public string BienInversion { get; set; }

    }
}
