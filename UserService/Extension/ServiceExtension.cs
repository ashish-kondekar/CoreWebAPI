using Microsoft.Extensions.DependencyInjection;
using User.Core.Interfaces.Core;
using User.Core;
using User.Core.Interfaces.Repo;
using User.Repo;

namespace User.Api.Extension
{
    public static class ServiceExtension
    {
        public static void AddUserCoreServices(this IServiceCollection services)
        {
            services.AddTransient<IUserCoreService, UserCoreService>();
        }

        public static void AddUserRepoServices(this IServiceCollection services)
        {
            services.AddTransient<IUserCoreRepository, UserCoreRepository>();
        }
    }
}
