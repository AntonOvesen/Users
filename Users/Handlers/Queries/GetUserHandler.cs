using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Users.Models.DTOs;
using Users.Persistence;

namespace Users.Handlers.Queries
{
    public class GetUser : IRequest<UserDTO>
    {
        public Guid Id { get; set; }
    }
    public class GetUserHandler : IRequestHandler<GetUser, UserDTO>
    {
        private readonly IMapper mapper;
        private readonly UsersContext context;

        public GetUserHandler(IMapper mapper, UsersContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<UserDTO> Handle(GetUser request, CancellationToken cancellationToken)
        {
            var entity = await context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

            return entity != null ? mapper.Map<UserDTO>(entity) : default;
        }
    }
}
