using System.Collections.Generic;
using System.Threading.Tasks;

namespace User.Core.Interfaces.Core
{
    public interface IUserCoreService
    {
        Task<UserDTO> GetUser(int userId);
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<UserDTO> CreateUser(UserDTO user);
        Task UpdateUser(int userId, UserDTO user);
        Task DeleteUser(int userId);
    }
}
