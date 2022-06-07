using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultas.SII.Entities.Enumerator
{
	public enum EnumEstadoCuadre
	{
		NoContrastable = 1,
		EnProcesoDeContraste = 2,
		NoContrastada = 3,
		ParcialmenteContrastada = 4,
		Contrastada = 5
	}
}
