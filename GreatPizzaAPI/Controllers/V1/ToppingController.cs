﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GreatPizzaAPI.Services;
using GreatPizzaAPI.Contracts;
using GreatPizzaAPI.Contracts.V1.Requests;
using GreatPizzaAPI.Domains;
using Microsoft.Extensions.Logging;

namespace GreatPizzaAPI.Controllers.V1
{
    [Produces("application/json")]
    public class ToppingController : Controller
    {
        private readonly IToppingService _toppingService;

        private readonly IUriService _uriService;
        
        private ILogger _logger;

        public ToppingController(IToppingService toppingService, IUriService uriService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PizzaController>();
            _toppingService = toppingService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoutes.Topping.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _toppingService.GetAllAsync());
        }
        
        [HttpGet(ApiRoutes.Topping.Get)]
        public async Task<IActionResult> Get([FromRoute]Guid toppingId)
        {
            var topping = await _toppingService.GetByIdAsync(toppingId);
            if (topping == null)
            {
                _logger.LogInformation(string.Format("{0}: Topping not found with ID {1}", "ToppingController.Get", toppingId));
                return NotFound();
            }
            return Ok(topping);
        }

        [HttpPost(ApiRoutes.Topping.Create)]
        public async Task<IActionResult> Create([FromBody] CreateToppingRequest createToppingRequest)
        {
            var newToppingId = Guid.NewGuid();
            var topping = new Topping
            {
                Id = newToppingId,
                Name = createToppingRequest.Name
            };
            await _toppingService.CreateAsync(topping);
            var locationUri = _uriService.GetToppingUri(topping.Id.ToString());
            return Created(locationUri, topping);
        }

        [HttpPut(ApiRoutes.Topping.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid toppingId, [FromBody] UpdateToppingRequest request)
        {
            var topping = await _toppingService.GetByIdAsync(toppingId);
            topping.Name = request.Name;
            var updated = await _toppingService.UpdateAsync(topping);
            if (updated)
                return Ok(topping);
            _logger.LogInformation(string.Format("{0}: Topping not found with ID {1}", "ToppingController.Update", toppingId));
            return NotFound();
        }

        [HttpDelete(ApiRoutes.Topping.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid toppingId)
        {
            var deleted = await _toppingService.DeleteAsync(toppingId);
            if (deleted)
                return NoContent();
            _logger.LogInformation(string.Format("{0}: Topping not found with ID {1}", "ToppingController.Delete", toppingId));
            return NotFound();
        }

        [HttpGet(ApiRoutes.Topping.GetAllByPizzaId)]
        public async Task<IActionResult> GetAllByPizzaId([FromRoute] Guid pizzaId)
        {
            return Ok(await _toppingService.GetAllByPizzaId(pizzaId));
        }

        [HttpGet(ApiRoutes.Topping.GetAllAvailableByPizzaId)]
        public async Task<IActionResult> GetAllAvailableByPizzaId([FromRoute] Guid pizzaId)
        {
            return Ok(await _toppingService.GetAllAvailableByPizzaId(pizzaId));
        }
    }
}
