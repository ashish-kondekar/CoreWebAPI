using System.Collections.Generic;
using System.Threading.Tasks;
using User.Repo;

namespace User.Core.Interfaces.Repo
{
    public interface IUserCoreRepository
    {
        Task<SysUser> GetUser(int id);
        Task<IEnumerable<SysUser>> GetUsers();
    }
}
