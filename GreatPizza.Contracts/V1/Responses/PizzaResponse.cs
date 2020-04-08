using System;
using System.Collections.Generic;
using System.Text;

namespace GreatPizza.Contracts.V1.Responses
{
    class PizzaResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
