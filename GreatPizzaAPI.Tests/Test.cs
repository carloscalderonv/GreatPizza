using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using GreatPizzaAPI.Contracts.V1.Requests;
using GreatPizzaAPI.Data;
using GreatPizzaAPI.Domains;
using GreatPizzaAPI.Contracts;
using Newtonsoft.Json;

namespace GreatPizzaAPI.Tests
{
    public class Test : IDisposable
    {
        protected readonly HttpClient TestClient;
        private readonly IServiceProvider _serviceProvider;
        protected Test()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(DataContext));
                        services.AddDbContext<DataContext>();
                    });
                });

            _serviceProvider = appFactory.Services;
            TestClient = appFactory.CreateClient();
        }

        protected async Task<Pizza> CreatePizzaAsync(CreatePizzaRequest request)
        {
            string json = JsonConvert.SerializeObject(request, Formatting.Indented);
            var httpContent = new StringContent(json);
            var response = await TestClient.PostAsync(ApiRoutes.Pizza.Create, httpContent);
            return await response.Content.ReadAsAsync<Pizza>();
        }

        public void Dispose()
        {
            using var serviceScope = _serviceProvider.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<DataContext>();
            context.Database.EnsureDeleted();
        }
    }
}
