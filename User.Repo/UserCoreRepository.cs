using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.Core.Interfaces.Repo;

namespace User.Repo
{
    public class UserCoreRepository : IUserCoreRepository
    {
        private readonly UserDBContext context;

        public UserCoreRepository(UserDBContext context)
        {
            this.context = context;
        }

        public async Task<SysUser> GetUser(int userId)
        {
            return await context.Users.AsTracking()
                .SingleAsync(user => user.UserId == userId)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<SysUser>> GetUsers()
        {
            return await context.Users.ToListAsync().ConfigureAwait(false);
        }

        public async Task<SysUser> CreateUser(SysUser user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return user;
        }

        public async Task UpdateUser(SysUser user)
        {
            context.Update(user);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteUser(SysUser user)
        {
            context.Remove(user);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
