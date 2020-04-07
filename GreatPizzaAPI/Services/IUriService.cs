using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreatPizzaAPI.Services
{
    public interface IUriService
    {
        Uri GetPizzaUri(string pizzaId);
        
        Uri GetToppingUri(string toppingId);
    }
}
