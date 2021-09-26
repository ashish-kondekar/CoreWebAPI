using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.Core.Interfaces.Core;
using User.Core.Interfaces.Repo;

namespace User.Core
{
    public class UserCoreService : IUserCoreService
    {
        private readonly IUserCoreRepository userRepo;
        private readonly IMapper mapper;

        public UserCoreService(IUserCoreRepository userRepo,
                               IMapper mapper)
        {
            this.userRepo = userRepo;
            this.mapper = mapper;
        }

        public async Task<UserDTO> GetUser(int id)
        {
            var user = await userRepo.GetUser(id).ConfigureAwait(false);
            return mapper.Map<UserDTO>(user);
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var users = await userRepo.GetUsers().ConfigureAwait(false);
            return mapper.Map<IEnumerable<UserDTO>>(users);
        }
    }
}
