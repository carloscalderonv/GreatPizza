using System;
using GreatPizzaAPI.Contracts;

namespace GreatPizzaAPI.Services
{
    public class UriService:IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPizzaUri(string pizzaId)
        {
            return new Uri(_baseUri + ApiRoutes.Pizza.Get.Replace("{pizzaId}", pizzaId));
        }

        public Uri GetToppingUri(string toppingId)
        {
            return new Uri(_baseUri + ApiRoutes.Topping.Get.Replace("{toppingId}", toppingId));
        }
    }
}
