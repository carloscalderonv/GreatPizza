using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GreatPizzaAPI.Services;
using GreatPizza.Contracts;
using GreatPizza.Contracts.V1.Requests;
using GreatPizzaAPI.Domains;
namespace GreatPizzaAPI.Controllers.V1
{
    [Produces("application/json")]
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;

        private readonly IUriService _uriService;

        public PizzaController(IPizzaService pizzaService, IUriService uriService)
        {
            _pizzaService = pizzaService;
            _uriService = uriService;
        }

        /// <summary>
        /// Return all Pizzas
        /// </summary> 
        /// <response code="200">Return all Pizzas</response>
        [HttpGet(ApiRoutes.Pizza.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _pizzaService.GetAllAsync());
        }

        /// <summary>
        /// Return a Pizzas based on the ID
        /// </summary> 
        /// <response code="200">Return the selected Pizza</response>
        [HttpGet(ApiRoutes.Pizza.Get)]
        public async Task<IActionResult> Get([FromRoute]Guid pizzaId)
        {
            var pizza = await _pizzaService.GetByIdAsync(pizzaId);
            if (pizza == null)
                return NotFound();
            return Ok(pizza);
        }

        /// <summary>
        /// Create a pizza from data provided
        /// </summary> 
        /// <response code="201">Pizza was created successfully</response>
        [HttpPost(ApiRoutes.Pizza.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePizzaRequest createPizzaRequest)
        {
            var newPizzaId = Guid.NewGuid();
            var pizza = new Pizza
            {
                Id = newPizzaId,
                Name = createPizzaRequest.Name,
                Description = createPizzaRequest.Description,
            };
            await _pizzaService.CreateAsync(pizza);
            var locationUri = _uriService.GetPizzaUri(pizza.Id.ToString());
            return Created(locationUri, pizza);
        }

        /// <summary>
        /// Update a especific Pizza 
        /// </summary> 
        /// <response code="200">Pizza was updated successfully</response>
        /// <response code="404">Pizza was not found in the system</response>
        [HttpPut(ApiRoutes.Pizza.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid pizzaId, [FromBody] UpdatePizzaRequest request)
        {
            var pizza = await _pizzaService.GetByIdAsync(pizzaId);
            pizza.Name = request.Name;
            pizza.Description = request.Description;
            var updated = await _pizzaService.UpdateAsync(pizza);
            if (updated)
                return Ok(pizza);
            return NotFound();
        }

        /// <summary>
        /// Delete a Pizza 
        /// </summary> 
        /// <response code="204">Pizza was deleted successfully</response>
        /// <response code="404">Pizza was not found in the system</response>
        [HttpDelete(ApiRoutes.Pizza.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid pizzaId)
        {
            var deleted = await _pizzaService.DeleteAsync(pizzaId);
            if (deleted)
                return NoContent();
            return NotFound();
        }

        /// <summary>
        /// Add a topping to a Pizza 
        /// </summary> 
        /// <response code="201">Topping was added to pizza successfully</response>
        /// <response code="409">Topping already exists on the Pizza</response>
        [HttpPost(ApiRoutes.Pizza.AddTopping)]
        public async Task<IActionResult> AddTopping([FromRoute] Guid pizzaId, [FromRoute] Guid toppingId)
        {
            var toppingpizza = await _pizzaService.GetToppingPizzaAsync(pizzaId, toppingId);
            if (toppingpizza != null)
            {
                return Conflict();
            }
            var newToppingPizzaId = Guid.NewGuid();
            var toppingPizza = new ToppingPizza
            {
                Id = newToppingPizzaId,
                PizzaId = pizzaId,
                ToppingId = toppingId,
            };
            await _pizzaService.AddToppingAsync(toppingPizza);
            var locationUri = _uriService.GetPizzaUri(toppingPizza.Id.ToString());
            return Created(locationUri, toppingPizza);
        }

        /// <summary>
        /// Remove a topping from the Pizza 
        /// </summary> 
        /// <response code="204">Topping was removed from pizza successfully</response>
        /// <response code="404">Topping did not exists on the Pizza</response>
        [HttpDelete(ApiRoutes.Pizza.RemoveTopping)]
        public async Task<IActionResult> RemoveTopping([FromRoute] Guid pizzaId, [FromRoute] Guid toppingId)
        {
            var toppingpizza = await _pizzaService.GetToppingPizzaAsync(pizzaId, toppingId);
            if (toppingpizza==null)
            {
                return NotFound();
            }
            var deleted = await _pizzaService.RemoveToppingAsync(toppingpizza.Id);
            if (deleted)
                return NoContent();
            return NotFound();
        }
    }
}
