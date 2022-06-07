using System.ComponentModel;

namespace Consultas.SII.Entities.Enumerator
{
	public enum EnumEstadoCobroPago
    {
		[Description("Pendiente de procesar")]
        Pendiente = 0,
		[Description("Procesado y pendiente de recibir respuesta")]
		PendienteRespuesta = 1,
		[Description("Procesado y Aceptado en la agencia tributaria")]
        Aceptado = 2,
		[Description("Procesado y Rechazado en la agencia tributaria")]
        Rechazado = 3,
    }
}
