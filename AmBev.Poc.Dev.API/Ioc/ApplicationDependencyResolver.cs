using Ambev.Poc.Dev.Data.Repository;
using Ambev.Poc.Dev.Domain.Interfaces.Repository;
using Ambev.Poc.Dev.Domain.Interfaces.Services;
using Ambev.Poc.Dev.Domain.Models.AppSettings;
using Ambev.Poc.Dev.Domain.Services.Order;
using Ambev.Poc.Dev.Domain.Services.Product;
using Ambev.Poc.Dev.Domain.Services.User;
using Microsoft.Extensions.Options;

namespace AmBev.Poc.Dev.API.Ioc
{
    public class ApplicationDependencyResolver
    {
        private static IServiceCollection _services;
        private static IConfiguration _configuration;


        public static void GetDependencies(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;

            ConfiguraAppSettings();
            AddRepositories();
            AddServices();
        }

        private static void ConfiguraAppSettings()
        {
            _services.Configure<AppSettings>(_configuration);
            _services.AddScoped(sp => sp.GetService<IOptionsSnapshot<AppSettings>>().Value);
        }

        private static void AddRepositories()
        {
            _services.AddScoped<IOrderRepository, OrderRepository>();
            _services.AddScoped<IUserRepository, UserRepository>();
            _services.AddScoped<IProductRepository, ProductRepository>();
        }

        private static void AddServices()
        {
            _services.AddScoped<IOrderService, OrderService>();
            _services.AddScoped<IProductService, ProductService>();
            _services.AddScoped<IUserService, UserService>();
        }
    }
}
