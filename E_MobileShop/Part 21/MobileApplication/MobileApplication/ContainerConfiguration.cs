using Microsoft.Extensions.DependencyInjection;
using MobileApplication.Contracts;
using MobileApplication.Repository;

namespace MobileApplication
{
    public class ContainerConfiguration
    {
        public static void DependencyMapping(IServiceCollection services)
        {
            services.AddScoped<IMobileBrands, MobileBrandRepository>();
        }
    }
}
