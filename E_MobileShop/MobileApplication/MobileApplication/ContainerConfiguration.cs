using Microsoft.Extensions.DependencyInjection;
using MobileApplication.Contracts;
using MobileApplication.Models;
using MobileApplication.Repository;

namespace MobileApplication
{
    public class ContainerConfiguration
    {
        public static void DependencyMapping(IServiceCollection services)
        {
            services.AddScoped<IRepositoryCRUD<MobileBrand>, MobileBrandRepository>();
            services.AddScoped<IRepositoryCRUD<ProductDetails>, ProductDetailsRepository>();
        }
    }
}
