using AutoMapper;
using MediatR;
using Users.Models.DTOs;
using Users.Models.Entities;
using Users.Persistence;

namespace Users.Handlers.Commands
{
    public class CreateUser : UserDTO, IRequest { }
    public class CreateUserHandler : IRequestHandler<CreateUser>
    {
        private readonly UsersContext context;
        private readonly IMapper mapper;

        public CreateUserHandler(UsersContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            request.Id = default;

            context.Users.Add(mapper.Map<User>(request));

            await context.SaveChangesAsync();

            return default;
        }
    }
}
