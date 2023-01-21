using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Users.Handlers.Commands;
using Users.Handlers.Queries;
using Users.Models.DTOs;

namespace Users.Controllers
{
    [ApiController]
    //[ApiVersion("1.0")]
    [Route("api/[Controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public UsersController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] CreateUser command)
        {
            await mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetUsers()
        {
            return Ok(await mediator.Send(new GetUsers()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(Guid id)
        {
            return Ok(await mediator.Send(new GetUser() { Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(Guid id, [FromBody] string name)
        {
            await mediator.Send(new UpdateUser() { Id = id, Name = name });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            await mediator.Send(new DeleteUser() { Id = id });
            return Ok();
        }
    }
}
