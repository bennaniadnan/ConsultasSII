using Consultas.SII.Contracts;
using Consultas.SII.Entities;
using Consultas.SII.Entities.Request;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultas.SII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationService _consultationService;

        public ConsultationController(IConsultationService consultationService)
        {
            _consultationService = consultationService;
        }

        public async Task<ActionResult<ICollection<ERegistroInformacion>>> ConsultationLR(ConsultaFacturasRequest request)
        {
            return Ok(await _consultationService.ConsultaLRAsync(request));
        }
    }
}
