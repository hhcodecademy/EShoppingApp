using EShoppingApp.EmailOperations;
using EShoppingApp.EmailOperations.Interfaces;
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
            services.AddScoped<IEmailSenderOpt,EmailSenderOpt>();
            //services.AddAutoMapper(typeof(CustomProfile));
        }
    }
}
