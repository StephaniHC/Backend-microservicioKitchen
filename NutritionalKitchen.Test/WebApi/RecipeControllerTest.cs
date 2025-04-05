using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NutritionalKitchen.Application.Recipe.CreateRecipe;
using NutritionalKitchen.Application.Recipe.GetRecipe;
using NutritionalKitchen.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.WebApi
{
    public class RecipeControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly RecipeController _controller;

        public RecipeControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new RecipeController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateRecipe_ShouldReturnOk_WhenSuccessful()
        {
            // Arrange
            var command = new CreateRecipeCommand(
                Guid.NewGuid(),
                "Pasta Carbonara",
                "30 minutes"
            );

            var expectedId = Guid.NewGuid();

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateRecipeCommand>(), default))
                .ReturnsAsync(expectedId);

            // Act
            var result = await _controller.CreateRecipe(command);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedId, actionResult.Value);
        }

        [Fact]
        public async Task CreateRecipe_ShouldReturnInternalServerError_WhenExceptionOccurs()
        {
            // Arrange
            var command = new CreateRecipeCommand(
                Guid.NewGuid(),
                "Pasta Carbonara",
                "30 minutes"
            );

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateRecipeCommand>(), default))
                .ThrowsAsync(new Exception("Database Error"));

            // Act
            var result = await _controller.CreateRecipe(command);

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, actionResult.StatusCode);
            Assert.Equal("Database Error", actionResult.Value);
        }

        [Fact]
        public async Task GetRecipe_ShouldReturnOk_WhenSuccessful()
        {
            // Arrange
            var recipes = new List<RecipeDto>
            {
                new RecipeDto { Id = Guid.NewGuid(), Name = "Pasta Carbonara", PreparationTime = "30 minutes" },
                new RecipeDto { Id = Guid.NewGuid(), Name = "Chicken Curry", PreparationTime = "45 minutes" }
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetRecipeQuery>(), default))
                .ReturnsAsync(recipes);

            // Act
            var result = await _controller.GetRecipe();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnedRecipes = Assert.IsAssignableFrom<IEnumerable<RecipeDto>>(actionResult.Value);
            Assert.Equal(recipes.Count, returnedRecipes.Count());
        }

        [Fact]
        public async Task GetRecipe_ShouldReturnInternalServerError_WhenExceptionOccurs()
        {
            // Arrange
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetRecipeQuery>(), default))
                .ThrowsAsync(new Exception("Service Unavailable"));

            // Act
            var result = await _controller.GetRecipe();

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, actionResult.StatusCode);
            Assert.Equal("Service Unavailable", actionResult.Value);
        }
    }
}
