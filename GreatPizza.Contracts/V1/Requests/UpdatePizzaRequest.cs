using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreatPizzaAPI.Contracts.V1.Requests
{
    public class UpdatePizzaRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
