using EShoppingApp.Repository;
using EShoppingApp.Repository.Interfaces;

namespace EShoppingApp.Extentions
{
    public static class CustomRepositoryRegistration
    {
        public static void AddCustomRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
