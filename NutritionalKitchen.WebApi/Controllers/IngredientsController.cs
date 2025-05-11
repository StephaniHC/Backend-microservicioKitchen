using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutritionalKitchen.Application.Ingredients.CreateIngredient;
using NutritionalKitchen.Application.Ingredients.GetIngredients;

namespace NutritionalKitchen.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IngredientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateIngredient([FromBody] CreateIngredientCommand command)
        {
            try
            {
                SentrySdk.CaptureMessage("Request executed successfully.");
                var id = await _mediator.Send(command); 
                return Ok(id);

            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetIngredients()
        {
            try
            {
                SentrySdk.CaptureMessage("Request executed successfully.");
                var result = await _mediator.Send(new GetIngredientsQuery(""));
                return Ok(result);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
