using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using GreatPizza.Contracts;
using GreatPizza.Contracts.V1.Responses;
using GreatPizza.Contracts.V1.Requests;
namespace GreatPizza.SDK
{
    public interface IGreatPizzaPizzaAPI
    {
        [Get("/api/v1/pizza/")]
        Task<ApiResponse<List<PizzaResponse>>>  GetAllPizzasAsync();

        [Get("/api/v1/pizza/{IdPizza}")]
        Task<ApiResponse<PizzaResponse>> GetPizzaAsync(Guid IdPizza);

        [Post("/api/v1/pizza/")]
        Task<ApiResponse<PizzaResponse>> CreatePizzaAsync([Body] CreatePizzaRequest createPizzaRequest);

        [Put("/api/v1/pizza/{IdPizza}")]
        Task<ApiResponse<PizzaResponse>> UpdatePizzaAsync(Guid IdPizza, [Body] UpdatePizzaRequest updatePizzaRequest);

        [Delete("/api/v1/pizza/{IdPizza}")]
        Task<ApiResponse<string>> DeletePizzaAsync(Guid IdPizza);
    }
}
