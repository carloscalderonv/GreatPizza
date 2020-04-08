using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Filters;
using GreatPizza.Contracts.V1.Requests;

namespace GreatPizzaAPI.Examples.Requests
{
    public class UpdatePizzaRequestExample : IExamplesProvider<UpdatePizzaRequest>
    {
        public UpdatePizzaRequest GetExamples()
        {
            return new UpdatePizzaRequest
            {
                Name = "New Pizza Name",
                Description = "This is the new description, the string could be long"
            };
        }
    }
}
