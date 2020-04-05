using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GreatPizzaAPI.Domains;
namespace GreatPizzaAPI.Services
{
    public interface IToppingService
    {
        Task<Topping> GetByIdAsync(Guid toppingId);
        Task<List<Topping>> GetAllAsync();
        Task<bool> CreateAsync(Topping topping);
        Task<bool> UpdateAsync(Topping toppingToUpdate);
        Task<bool> DeleteAsync(Guid toppingId);
    }
}
