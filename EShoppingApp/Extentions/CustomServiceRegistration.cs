using EShoppingApp.Services;
using EShoppingApp.Services.Interfaces;

namespace EShoppingApp.Extentions
{
    public static class CustomServiceRegistration
    {

        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            //services.AddAutoMapper(typeof(CustomProfile));
        }
    }
}
