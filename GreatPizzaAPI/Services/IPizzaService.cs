using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GreatPizzaAPI.Domains;

namespace GreatPizzaAPI.Services
{
    public interface IPizzaService
    {
        Task<Pizza> GetByIdAsync(Guid pizzaId);
        
        Task<List<Pizza>> GetAllAsync();
        
        Task<bool> CreateAsync(Pizza pizza);
        
        Task<bool> UpdateAsync(Pizza pizzaToUpdate);
        
        Task<bool> DeleteAsync(Guid pizzaId);
        
        Task<bool> AddToppingAsync(ToppingPizza toppingPizza);
        
        Task<bool> RemoveToppingAsync(Guid toppingPizza);
        
        Task<ToppingPizza> GetToppingPizzaAsync(Guid pizzaId, Guid toppingId);
        
        Task<ToppingPizza> GetToppingPizzaByIdAsync(Guid toppingPizzaId);
    }
}
