using AutoMapper;
using Gisys.WebApi.DataTransferObjects;
using Gisys.WebApi.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        /// Get a collection of consultants.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ConsultantResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetConsultantCollection()
        {
            var consultantCollection = _consultantService.GetConsultantCollection();

            if (consultantCollection == null)
            {
                return NoContent();
            }

            var mappedResult = _mapper.Map<IEnumerable<ConsultantResponseDto>>(consultantCollection);

            return Ok(mappedResult);
        }

        /// <summary>
        /// Get a consultant.
        /// </summary>
        /// <param name="consultantId"></param>
        /// <returns></returns>
        [HttpGet("{consultantId}")]
        [ProducesResponseType(typeof(ConsultantResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetConsultant([FromRoute] Guid consultantId)
        {
            var consultant = _consultantService.GetConsultant(consultantId);

            if (consultant == null)
            {
                return NotFound();
            }

            var mappedResult = _mapper.Map<ConsultantResponseDto>(consultant);

            return Ok(mappedResult);
        }

        /// <summary>
        /// Create a consultant.
        /// </summary>
        /// <param name="consultantRequestDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ConsultantResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateConsultant([FromBody] ConsultantRequestDto consultantRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consultant = _consultantService.CreateConsultant(consultantRequestDto);

            if (consultant == null)
            {
                return UnprocessableEntity();
            }

            var mappedResult = _mapper.Map<ConsultantResponseDto>(consultant);

            return Ok(mappedResult);
        }

        /// <summary>
        /// Update a consultant.
        /// </summary>
        /// <param name="consultantId"></param>
        /// <param name="consultantRequestDto"></param>
        /// <returns></returns>
        [HttpPut("{consultantId}")]
        [ProducesResponseType(typeof(ConsultantResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult UpdateConsultant([FromRoute] Guid consultantId, [FromBody] ConsultantRequestDto consultantRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consultant = _consultantService.UpdateConsultant(consultantId, consultantRequestDto);

            if (consultant == null)
            {
                return UnprocessableEntity();
            }

            var mappedResult = _mapper.Map<ConsultantResponseDto>(consultant);

            return Ok(mappedResult);
        }

        /// <summary>
        /// Delete a consultant.
        /// </summary>
        /// <param name="consultantId"></param>
        /// <returns></returns>
        [HttpDelete("{consultantId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult DeleteConsultant([FromRoute] Guid consultantId)
        {
            var consultant = _consultantService.DeleteConsultant(consultantId);

            if (consultant == false)
            {
                return UnprocessableEntity();
            }

            return Ok(true);
        }

        /// <summary>
        /// Get Consultant Share Of Bonus Pot.
        /// </summary>
        /// <param name="consultantId"></param>
        /// <returns></returns>
        [HttpGet("{consultantId}/shareOfBonusPot")]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetConsultantShareOfBonusPot([FromRoute] Guid consultantId)
        {
            var shareOfBonusPot = _consultantService.GetConsultantShareOfBonusPot(consultantId);

            if (shareOfBonusPot == 0)
            {
                return NotFound();
            }

            return Ok(Math.Round(shareOfBonusPot*100, 1));
        }

        /// <summary>
        /// Get consultant bonus.
        /// </summary>
        /// <param name="consultantId"></param>
        /// <returns></returns>
        [HttpGet("{consultantId}/{netResult}")]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetConsultantBonus([FromRoute] Guid consultantId)
        {
            var bonus = _consultantService.GetConsultantBonus(consultantId);

            if (bonus == 0)
            {
                return NotFound();
            }

            return Ok(bonus);
        }

    }
}
