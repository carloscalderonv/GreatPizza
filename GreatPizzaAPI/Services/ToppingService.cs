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

        public async Task<List<Topping>> GetAllAvailableByPizzaId(Guid pizzaId)
        {
            var toppingsIds = _dataContext.ToppingPizza.Where(p => p.PizzaId == pizzaId).Select(tp => tp.ToppingId).ToArray();

            var query = _dataContext.Topping.Where(p => !toppingsIds.Contains(p.Id));
            
            return await query.ToListAsync();
        }

        public async Task<List<Topping>> GetAllByPizzaId(Guid pizzaId)
        {
            var query = from tp in _dataContext.ToppingPizza
                        join t in _dataContext.Topping on tp.ToppingId equals t.Id
                        where tp.PizzaId==pizzaId 
                        select t;
            return await query.ToListAsync();
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
