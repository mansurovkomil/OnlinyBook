using OnlinyBook.Service.Common.Security;
using OnlinyBook.Service.Intefaces.Accounts;
using OnlinyBook.Service.Intefaces.Common;
using OnlinyBook.Service.Intefaces.Orders;
using OnlinyBook.Service.Intefaces.Products;
using OnlinyBook.Service.Intefaces.Security;
using OnlinyBook.Service.Intefaces.Users;
using OnlinyBook.Service.Service.Accounts;
using OnlinyBook.Service.Service.Common;
using OnlinyBook.Service.Service.Orders;
using OnlinyBook.Service.Service.Products;
using OnlinyBook.Service.Service.Users;

namespace OnlinyBook.Configurations.LayerConfigurations
{
    public static class ServiseLayerConfiguration
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<IIdentityService, IdentityService>();
		}
	}
}
