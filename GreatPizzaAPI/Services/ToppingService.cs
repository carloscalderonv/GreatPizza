using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GreatPizzaAPI.Data;
using GreatPizzaAPI.Domains;

namespace GreatPizzaAPI.Services
{
    public class ToppingService : IToppingService
    {
        private readonly DataContext _dataContext;

        public ToppingService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> CreateAsync(Topping topping)
        {
            await _dataContext.Topping.AddAsync(topping);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteAsync(Guid toppingId)
        {
            var topping = await GetByIdAsync(toppingId);

            if (topping == null)
                return false;

            _dataContext.Topping.Remove(topping);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<List<Topping>> GetAllAsync()
        {
            return await _dataContext.Topping.ToListAsync();
        }

        public async Task<Topping> GetByIdAsync(Guid toppingId)
        {
            return await _dataContext.Topping.SingleOrDefaultAsync(topping => topping.Id == toppingId);
        }

        public async Task<bool> UpdateAsync(Topping toppingToUpdate)
        {
            _dataContext.Topping.Update(toppingToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }
    }
}
