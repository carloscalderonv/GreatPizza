using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GreatPizzaAPI.Data;
using GreatPizzaAPI.Domains;

namespace GreatPizzaAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly DataContext _dataContext;

        public PizzaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> AddToppingAsync(ToppingPizza toppingPizza)
        {
            await _dataContext.ToppingPizza.AddAsync(toppingPizza);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> CreateAsync(Pizza pizza)
        {
            await _dataContext.Pizza.AddAsync(pizza);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteAsync(Guid pizzaId)
        {
            var pizza = await GetByIdAsync(pizzaId);

            if (pizza == null)
                return false;

            _dataContext.Pizza.Remove(pizza);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<Pizza> GetByIdAsync(Guid pizzaId)
        {
            return await _dataContext.Pizza.SingleOrDefaultAsync(pizza => pizza.Id == pizzaId);
        }

        public async Task<List<Pizza>> GetAllAsync()
        {
            return await _dataContext.Pizza.ToListAsync();
        }

        public async Task<bool> RemoveToppingAsync(Guid idToppingPizza)
        {
            var toppingPizzatmp = await GetToppingPizzaByIdAsync(idToppingPizza);

            if (toppingPizzatmp == null)
                return false;

            _dataContext.ToppingPizza.Remove(toppingPizzatmp);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<bool> UpdateAsync(Pizza pizzaToUpdate)
        {
            _dataContext.Pizza.Update(pizzaToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }
        public async Task<ToppingPizza> GetToppingPizzaAsync(Guid pizzaId, Guid toppingId)
        {
            return await _dataContext.ToppingPizza.SingleOrDefaultAsync(pizzaTopping => pizzaTopping.PizzaId == pizzaId && pizzaTopping.ToppingId==toppingId);
        }
        public async Task<ToppingPizza> GetToppingPizzaByIdAsync(Guid toppingPizzaId)
        {
            return await _dataContext.ToppingPizza.SingleOrDefaultAsync(pizzaTopping => pizzaTopping.Id == toppingPizzaId);
        }
    }
}
