using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreatPizzaAPI.Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;
        public static class Pizza
        {
            public const string Get = Base + "/pizza/{pizzaId}";
            public const string GetAll = Base + "/pizza";
            public const string Update = Base + "/pizza/{pizzaId}";
            public const string Delete = Base + "/pizza/{pizzaId}";
            public const string Create = Base + "/pizza";
            public const string AddTopping = Base + "/pizza/Topping/{pizzaId}/{toppingId}";
            public const string RemoveTopping = Base + "/pizza/Topping/{pizzaId}/{toppingId}";
        }
        public static class Topping
        {
            public const string Get = Base + "/topping/{toppingId}";
            public const string GetAll = Base + "/topping";
            public const string Update = Base + "/topping/{toppingId}";
            public const string Delete = Base + "/topping/{toppingId}";
            public const string Create = Base + "/topping";
            public const string GetAllByPizzaId = Base + "/topping/by-pizza/{pizzaId}";
            public const string GetAllAvailableByPizzaId = Base + "/topping/available-by-pizza/{pizzaId}";

        }
    }
}
