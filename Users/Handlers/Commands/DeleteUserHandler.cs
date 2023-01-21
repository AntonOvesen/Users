using MediatR;
using Microsoft.EntityFrameworkCore;
using Users.Persistence;

namespace Users.Handlers.Commands
{
    public class DeleteUser : IRequest
    {
        public Guid Id { get; set; }
    }
    public class DeleteUserHandler : IRequestHandler<DeleteUser>
    {
        private readonly UsersContext context;

        public DeleteUserHandler(UsersContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var entity = await context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

            if(entity == null) { return default; }

            context.Users.Remove(entity);

            await context.SaveChangesAsync();

            return default;
        }
    }
}
