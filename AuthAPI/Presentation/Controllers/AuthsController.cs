using Application.Handlers.Auths.Commands;
using Application.Handlers.Auths.DTOs;
using Application.Handlers.Auths.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("HealthCheckup")]
        public async Task<IActionResult> GetHealthCheckup()
        {
            var result = await this._mediator.Send(new GetHealthCheckupQuery());
            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RequestRegisterUserDto dto)
        {
            var result = await this._mediator.Send(new RegisterUserCommand(dto));
            return Ok(result);
        }
    }
}
