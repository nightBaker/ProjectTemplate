using ProjectTemplate.WEB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;
using ProjectTemplate.APPLICATION.Dtos.Queries.SomeQueries.SomethingList;

namespace ProjectTemplate.WEB.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SomesController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger<SomesController> logger;

        public SomesController(IMediator mediator, ILogger<SomesController> logger)
        {
            _mediator = mediator;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery]SomethingListQuery query)
        {
            var somes = await _mediator.Send(query);

            return Ok(somes);
        }
    }
}
