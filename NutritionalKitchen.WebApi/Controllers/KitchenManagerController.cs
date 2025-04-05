using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutritionalKitchen.Application.Ingredients.CreateIngredient;
using NutritionalKitchen.Application.Ingredients.GetIngredients;
using NutritionalKitchen.Application.KitchenManager.CreateKitchenManager;
using NutritionalKitchen.Application.KitchenManager.GetKitchenManager;

namespace NutritionalKitchen.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitchenManagerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public KitchenManagerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateKitchenManager([FromBody] CreateKitchenManagerCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);

                return Ok(id);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetKitchenManager()
        {
            try
            {
                var result = await _mediator.Send(new GetKitchenManagerQuery(""));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
