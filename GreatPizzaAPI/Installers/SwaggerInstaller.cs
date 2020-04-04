using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace GreatPizzaAPI.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(swaggergen =>
            {
                swaggergen.SwaggerDoc("v1", new OpenApiInfo { Title = "Great Pizza API", Version = "v1" });
            });
        }
    }
}
