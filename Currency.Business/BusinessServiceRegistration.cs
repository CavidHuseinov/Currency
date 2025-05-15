
using Currency.Business.Services.Implementations;
using Currency.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Currency.Business
{
    public static class BusinessServiceRegistration
    {
        public static void AddBusinessService(this IServiceCollection services)
        {
            services.AddScoped<ICurrencyService,CurrencyService>();
        }
    }
}
