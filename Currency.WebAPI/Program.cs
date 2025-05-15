
using Currency.Business;
using Currency.Core.Settings;

namespace Currency.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<CurrencySettings>(builder.Configuration.GetSection("CurrencySettings"));
            BusinessServiceRegistration.AddBusinessService(builder.Services);
            builder.Services.AddHttpClient();
            builder.Services.AddMemoryCache();

            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
