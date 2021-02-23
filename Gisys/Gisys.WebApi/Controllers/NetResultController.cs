using AutoMapper;
using Gisys.WebApi.DataTransferObjects;
using Gisys.WebApi.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gisys.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class NetResultController : ControllerBase
    {
        private readonly INetResultService _netResultService;
        private readonly IMapper _mapper;

        public NetResultController(INetResultService netResultService, IMapper mapper)
        {
            _netResultService = netResultService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get Net Result
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(NetResultResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetNetResult()
        {
            var netResult = _netResultService.GetNetResult();

            if (netResult == null)
            {
                return NotFound();
            }

            var mappedResult = _mapper.Map<NetResultResponseDto>(netResult);

            return Ok(mappedResult);
        }

        /// <summary>
        /// Create Net Result.
        /// </summary>
        /// <param name="netResultRequestDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult CreateNetResult([FromBody] NetResultRequestDto netResultRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var netResult = _netResultService.CreateNetResult(netResultRequestDto.Net);

            if (netResult == null)
            {
                return UnprocessableEntity();
            }

            return Ok(netResult.Net);
        }

        /// <summary>
        /// Update Net Result.
        /// </summary>
        /// <param name="netResultId"></param>
        /// <param name="netResultRequestDto"></param>
        /// <returns></returns>
        [HttpPut("{netResultId}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult UpdateNetResult([FromRoute] Guid netResultId, [FromBody] NetResultRequestDto netResultRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var netResult = _netResultService.UpdateNetResult(netResultId, netResultRequestDto.Net);

            if (netResult == null)
            {
                return UnprocessableEntity();
            }

            return Ok(netResult.Net);
        }

    }
}
