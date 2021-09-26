using System.Collections.Generic;
using System.Threading.Tasks;

namespace User.Core.Interfaces.Core
{
    public interface IUserCoreService
    {
        Task<UserDTO> GetUser(int id);
        Task<IEnumerable<UserDTO>> GetUsers();
    }
}
