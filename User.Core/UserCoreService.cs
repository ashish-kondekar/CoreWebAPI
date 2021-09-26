using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.Core.DTOs;
using User.Core.Interfaces.Core;
using User.Core.Interfaces.Repo;
using User.Repo;

namespace User.Core
{
    public class UserCoreService : IUserCoreService
    {
        private readonly IUserCoreRepository _userRepo;
        private readonly IMapper _mapper;

        public UserCoreService(IUserCoreRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUser(int userId)
        {
            var sysUser = await _userRepo.GetUser(userId).ConfigureAwait(false);
            return _mapper.Map<UserDTO>(sysUser);
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var users = await _userRepo.GetUsers().ConfigureAwait(false);
            _mapper.Map<IEnumerable<UserDTO>>(users);
            throw new BusinessException("This is business exception.");
        }

        public async Task<UserDTO> CreateUser(UserDTO user)
        {
            var sysUser = await _userRepo.CreateUser(_mapper.Map<SysUser>(user));
            return _mapper.Map<UserDTO>(sysUser);
        }

        public async Task UpdateUser(int userId, UserDTO user)
        {
            var sysUser = await _userRepo.GetUser(userId).ConfigureAwait(false);
            await _userRepo.UpdateUser(sysUser).ConfigureAwait(false);
        }

        public async Task DeleteUser(int userId)
        {
            var sysUser = await _userRepo.GetUser(userId).ConfigureAwait(false);
            await _userRepo.DeleteUser(sysUser).ConfigureAwait(false);
        }
    }
}
