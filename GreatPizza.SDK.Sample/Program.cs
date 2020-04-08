using System;
using System.Threading.Tasks;
using GreatPizza.Contracts.V1.Requests;
using Refit;


namespace GreatPizza.SDK.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var greatPizzaPizzaAPI = RestService.For<IGreatPizzaPizzaAPI>("https://localhost:5001/");
            var greatPizzaToppingAPI = RestService.For<IGreatPizzaToppingAPI>("https://localhost:5001/");
            
            var allpizzas= await greatPizzaPizzaAPI.GetAllPizzasAsync();
            
            var createdPizza = await greatPizzaPizzaAPI.CreatePizzaAsync(new CreatePizzaRequest
            {
                Name = "SDKPizza",
                Description = "This Pizza was Created From SDK"
            });

            var onePizza = await greatPizzaPizzaAPI.GetPizzaAsync(createdPizza.Content.Id);

            var updatedPizza= await greatPizzaPizzaAPI.UpdatePizzaAsync(createdPizza.Content.Id, new UpdatePizzaRequest
            {
                Name = "New SDKPizza",
                Description = "This Pizza was UPDATED From SDK"
            });

            var deletedPizza = await greatPizzaPizzaAPI.DeletePizzaAsync(createdPizza.Content.Id);

            var alltopping = await greatPizzaToppingAPI.GetAllToppingsAsync();
            
            var createdtopping = await greatPizzaToppingAPI.CreateToppingAsync(new CreateToppingRequest
            {
                Name = "SDKTopping"
            });

            var onetopping = await greatPizzaToppingAPI.GetToppingAsync(createdtopping.Content.Id);

            var updatedtopping = await greatPizzaToppingAPI.UpdateToppingAsync(createdtopping.Content.Id, new UpdateToppingRequest
            {
                Name = "New SDKTopping"
            });

            var deletedtopping = await greatPizzaToppingAPI.DeleteToppingAsync(createdtopping.Content.Id);


        }
    }
}
