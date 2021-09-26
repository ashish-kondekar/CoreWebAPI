using AutoMapper;
using User.Core;
using User.Repo;

namespace User.Api.Extension
{
    public class AutoMapperProfileExtension : Profile
    {
        public AutoMapperProfileExtension()
        {
            CreateMap<SysUser, UserDTO>();
        }
    }
}
