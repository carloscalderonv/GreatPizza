using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using GreatPizza.Contracts;
using GreatPizza.Contracts.V1.Responses;
using GreatPizza.Contracts.V1.Requests;
namespace GreatPizza.SDK
{
    public interface IGreatPizzaToppingAPI
    {
        [Get("/api/v1/topping/")]
        Task<ApiResponse<List<ToppingResponse>>>  GetAllToppingsAsync();

        [Get("/api/v1/topping/{IdTopping}")]
        Task<ApiResponse<ToppingResponse>> GetToppingAsync(Guid IdTopping);

        [Post("/api/v1/topping/")]
        Task<ApiResponse<ToppingResponse>> CreateToppingAsync([Body] CreateToppingRequest createToppingRequest);

        [Put("/api/v1/topping/{IdTopping}")]
        Task<ApiResponse<ToppingResponse>> UpdateToppingAsync(Guid IdTopping, [Body] UpdateToppingRequest updateToppingRequest);

        [Delete("/api/v1/topping/{IdTopping}")]
        Task<ApiResponse<string>> DeleteToppingAsync(Guid IdTopping);
    }
}
