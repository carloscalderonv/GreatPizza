using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GreatPizzaAPI.Data;
using GreatPizzaAPI.Domains;
using Microsoft.Extensions.Logging;

namespace GreatPizzaAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly DataContext _dataContext;
        
        ILogger _logger;
        public PizzaService(DataContext dataContext, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PizzaService>();
            _dataContext = dataContext;
        }

        public async Task<bool> AddToppingAsync(ToppingPizza toppingPizza)
        {
            try
            {
                await _dataContext.ToppingPizza.AddAsync(toppingPizza);
                var created = await _dataContext.SaveChangesAsync();
                return created > 0;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "AddToppingAsync");
                return false;
            }
        }

        public async Task<bool> CreateAsync(Pizza pizza)
        {
            try
            {
                await _dataContext.Pizza.AddAsync(pizza);
                var created = await _dataContext.SaveChangesAsync();
                return created > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateAsync");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid pizzaId)
        {
            try
            {
                var pizza = await GetByIdAsync(pizzaId);
                if (pizza == null)
                    return false;
                _dataContext.Pizza.Remove(pizza);
                var deleted = await _dataContext.SaveChangesAsync();
                return deleted > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DeleteAsync");
                return false;
            }
        }

        public async Task<Pizza> GetByIdAsync(Guid pizzaId)
        {
            try
            {
                return await _dataContext.Pizza.SingleOrDefaultAsync(pizza => pizza.Id == pizzaId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetByIdAsync");
                return new Pizza();
            }
        }

        public async Task<List<Pizza>> GetAllAsync()
        {
            try
            {
                return await _dataContext.Pizza.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAllAsync");
                return new List<Pizza>();
            }
        }

        public async Task<bool> RemoveToppingAsync(Guid idToppingPizza)
        {
            try
            {
                var toppingPizzatmp = await GetToppingPizzaByIdAsync(idToppingPizza);
                if (toppingPizzatmp == null)
                    return false;
                _dataContext.ToppingPizza.Remove(toppingPizzatmp);
                var deleted = await _dataContext.SaveChangesAsync();
                return deleted > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "RemoveToppingAsync");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Pizza pizzaToUpdate)
        {
            try
            {
                _dataContext.Pizza.Update(pizzaToUpdate);
                var updated = await _dataContext.SaveChangesAsync();
                return updated > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UpdateAsync");
                return false;
            }
        }

        public async Task<ToppingPizza> GetToppingPizzaAsync(Guid pizzaId, Guid toppingId)
        {
            try
            {
                return await _dataContext.ToppingPizza.SingleOrDefaultAsync(pizzaTopping => pizzaTopping.PizzaId == pizzaId && pizzaTopping.ToppingId==toppingId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetToppingPizzaAsync");
                return new ToppingPizza();
            }
        }

        public async Task<ToppingPizza> GetToppingPizzaByIdAsync(Guid toppingPizzaId)
        {
            try
            {
                return await _dataContext.ToppingPizza.SingleOrDefaultAsync(pizzaTopping => pizzaTopping.Id == toppingPizzaId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetToppingPizzaByIdAsync");
                return new ToppingPizza();
            }
        }
    }
}
