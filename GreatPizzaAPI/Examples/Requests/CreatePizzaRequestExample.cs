using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Filters;
using GreatPizza.Contracts.V1.Requests;


namespace GreatPizzaAPI.Examples.Requests
{
    public class CreatePizzaRequestExample : IExamplesProvider<CreatePizzaRequest>
    {
        public CreatePizzaRequest GetExamples()
        {
            return new CreatePizzaRequest
            {
                Name = "Pizza Name",
                Description = "This is the description, the string could be long"
            };
        }
    }
}
