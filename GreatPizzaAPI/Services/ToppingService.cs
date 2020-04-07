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
    public class ToppingService : IToppingService
    {
        private readonly DataContext _dataContext;
        ILogger _logger;

        public ToppingService(DataContext dataContext, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PizzaService>();
            _dataContext = dataContext;
        }
        public async Task<bool> CreateAsync(Topping topping)
        {
            try
            {
                await _dataContext.Topping.AddAsync(topping);
                var created = await _dataContext.SaveChangesAsync();
                return created > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateAsync");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid toppingId)
        {
            try
            {
                var topping = await GetByIdAsync(toppingId);

                if (topping == null)
                    return false;

                _dataContext.Topping.Remove(topping);
                var deleted = await _dataContext.SaveChangesAsync();
                return deleted > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DeleteAsync");
                return false;
            }
        }

        public async Task<List<Topping>> GetAllAsync()
        {
            try
            {
                return await _dataContext.Topping.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAllAsync");
                return new List<Topping>();
            }
        }

        public async Task<List<Topping>> GetAllAvailableByPizzaId(Guid pizzaId)
        {
            try
            {
                var toppingsIds = _dataContext.ToppingPizza.Where(p => p.PizzaId == pizzaId).Select(tp => tp.ToppingId).ToArray();

                var query = _dataContext.Topping.Where(p => !toppingsIds.Contains(p.Id));
            
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAllAvailableByPizzaId");
                return new List<Topping>();
            }
        }

        public async Task<List<Topping>> GetAllByPizzaId(Guid pizzaId)
        {
            try
            {
                var query = from tp in _dataContext.ToppingPizza
                            join t in _dataContext.Topping on tp.ToppingId equals t.Id
                            where tp.PizzaId==pizzaId 
                            select t;
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAllByPizzaId");
                return new List<Topping>();
            }
        }

        public async Task<Topping> GetByIdAsync(Guid toppingId)
        {
            try
            {
                return await _dataContext.Topping.SingleOrDefaultAsync(topping => topping.Id == toppingId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetByIdAsync");
                return new Topping();
            }
        }

        public async Task<bool> UpdateAsync(Topping toppingToUpdate)
        {
            try
            {
                _dataContext.Topping.Update(toppingToUpdate);
                var updated = await _dataContext.SaveChangesAsync();
                return updated > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UpdateAsync");
                return false;
            }
        }
    }
}
