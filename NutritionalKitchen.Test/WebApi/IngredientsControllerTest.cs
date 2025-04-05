using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NutritionalKitchen.Application.Ingredients.CreateIngredient;
using NutritionalKitchen.Application.Ingredients.GetIngredients;
using NutritionalKitchen.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.WebApi
{
    public class IngredientsControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly IngredientsController _controller;

        public IngredientsControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new IngredientsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateIngredient_ShouldReturnOk_WhenSuccessful()
        {
            // Arrange
            var command = new CreateIngredientCommand(Guid.NewGuid(), "Tomato");
            var expectedId = Guid.NewGuid();

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateIngredientCommand>(), default))
                .ReturnsAsync(expectedId);

            // Act
            var result = await _controller.CreateIngredient(command);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedId, actionResult.Value);
        }

        [Fact]
        public async Task CreateIngredient_ShouldReturnInternalServerError_WhenExceptionOccurs()
        {
            // Arrange
            var command = new CreateIngredientCommand(Guid.NewGuid(), "Tomato");

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateIngredientCommand>(), default))
                .ThrowsAsync(new Exception("Error"));

            // Act
            var result = await _controller.CreateIngredient(command);

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, actionResult.StatusCode);
            Assert.Equal("Error", actionResult.Value);
        }

        [Fact]
        public async Task GetIngredients_ShouldReturnOk_WhenSuccessful()
        {
            // Arrange
            var ingredients = new List<IngredientDto>
            {
                new IngredientDto { Id = Guid.NewGuid(), Name = "Tomato" },
                new IngredientDto { Id = Guid.NewGuid(), Name = "Onion" }
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetIngredientsQuery>(), default))
                .ReturnsAsync(ingredients);

            // Act
            var result = await _controller.GetIngredients();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnedIngredients = Assert.IsAssignableFrom<IEnumerable<IngredientDto>>(actionResult.Value);
            Assert.Equal(ingredients.Count, returnedIngredients.Count());
        }

        [Fact]
        public async Task GetIngredients_ShouldReturnInternalServerError_WhenExceptionOccurs()
        {
            // Arrange
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetIngredientsQuery>(), default))
                .ThrowsAsync(new Exception("Database Error"));

            // Act
            var result = await _controller.GetIngredients();

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, actionResult.StatusCode);
            Assert.Equal("Database Error", actionResult.Value);
        }
    }
}
