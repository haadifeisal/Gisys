using AutoMapper;
using Gisys.WebApi.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gisys.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ConsultantController : ControllerBase
    {
        private readonly IConsultantService _consultantService;
        private readonly IMapper _mapper;

        public ConsultantController(IConsultantService consultantService, IMapper mapper)
        {
            _consultantService = consultantService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get consultant.
        /// </summary>
        /// <param name="consultantId"></param>
        /// <returns></returns>
        [HttpGet("{consultantId}")]
        //[ProducesResponseType(typeof(LibraryItemResponseDto), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetConsultant([FromRoute] Guid consultantId)
        {
            var consultant = _consultantService.GetConsultant(consultantId);

            if (consultant == null)
            {
                return NotFound();
            }

            //var mappedResult = _mapper.Map<LibraryItemResponseDto>(consultant);

            return Ok(consultant);
        }

    }
}
