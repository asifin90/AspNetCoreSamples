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
            services.AddScoped<IRepositoryUser, UserRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IProductDetailsRepo, ProductDetailsRepository>();
            services.AddScoped<ICartProductsRepository, CartProductsRepository>();
        }
    }
}
