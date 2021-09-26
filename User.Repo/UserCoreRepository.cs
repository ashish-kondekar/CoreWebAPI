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

        public async Task<SysUser> GetUser(int id)
        {
            return await context.Users.SingleAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<SysUser>> GetUsers()
        {
            return await context.Users.ToListAsync().ConfigureAwait(false);
        }
    }
}
