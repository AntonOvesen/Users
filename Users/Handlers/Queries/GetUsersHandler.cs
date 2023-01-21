using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Users.Models.DTOs;
using Users.Persistence;

namespace Users.Handlers.Queries
{
    public class GetUsers : IRequest<List<UserDTO>> { }
    public class GetUsersHandler : IRequestHandler<GetUsers, List<UserDTO>>
    {
        private readonly IMapper mapper;
        private readonly UsersContext context;

        public GetUsersHandler(IMapper mapper, UsersContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<List<UserDTO>> Handle(GetUsers request, CancellationToken cancellationToken)
        {
            var userEntities = await context.Users.ToListAsync();

            return mapper.Map<List<UserDTO>>(userEntities);
        }
    }
}
