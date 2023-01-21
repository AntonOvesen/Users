using MediatR;
using Microsoft.EntityFrameworkCore;
using Users.Persistence;

namespace Users.Handlers.Commands
{
    public class UpdateUser : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateUserHandler : IRequestHandler<UpdateUser>
    {
        private readonly UsersContext context;

        public UpdateUserHandler(UsersContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var entity = await context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

            if(entity == null) { return default; }

            entity.Name = request.Name;

            await context.SaveChangesAsync();

            return default;
        }
    }
}
