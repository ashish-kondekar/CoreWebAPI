using System.Collections.Generic;
using System.Threading.Tasks;
using User.Repo;

namespace User.Core.Interfaces.Repo
{
    public interface IUserCoreRepository
    {
        Task<SysUser> GetUser(int userId);
        Task<IEnumerable<SysUser>> GetUsers();
        Task<SysUser> CreateUser(SysUser user);
        Task UpdateUser(SysUser user);
        Task DeleteUser(SysUser user);
    }
}
