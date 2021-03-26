using Example.Domain.Commads;
using Example.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;


        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public string Get()
        {
            return _mediator.Send(new GetAllOrdersQuery()).Result;
        }

        [HttpPost]
        public string GetById([FromBody ]int getByID)
        {
            return _mediator.Send(new GetByIdOrderQuery(getByID)).Result;
        }

        [HttpPost("CreateText")]
        public string CreateText([FromBody] CreateTextCommad CreateTextCommad)
        {
            return _mediator.Send(CreateTextCommad).Result;
        }
    }
}
