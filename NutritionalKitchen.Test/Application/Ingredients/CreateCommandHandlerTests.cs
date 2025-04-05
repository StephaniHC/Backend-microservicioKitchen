using Moq;
using NutritionalKitchen.Application.Ingredients.CreateIngredient;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Application.Ingredients
{
    public class CreateCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldCreateIngredient_AndReturnId_WhenValidRequest()
        {
            // Arrange
            var ingredientId = Guid.NewGuid();
            var ingredientName = "Tomato";
            var command = new CreateIngredientCommand(ingredientId, ingredientName);

            var mockIngredientFactory = new Mock<IIngredientFactory>();
            var mockIngredientRepository = new Mock<IIngredientsRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var createdIngredient = new NutritionalKitchen.Domain.Ingredients.Ingredients(ingredientId, ingredientName);

            mockIngredientFactory
                .Setup(factory => factory.Create(ingredientId, ingredientName))
                .Returns(createdIngredient);

            var handler = new NutritionalKitchen.Application.Ingredients.CreateIngredient.CreateCommandHandler(
                mockIngredientFactory.Object,
                mockIngredientRepository.Object,
                mockUnitOfWork.Object
            );

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(ingredientId, result);

            mockIngredientFactory.Verify(factory => factory.Create(ingredientId, ingredientName), Times.Once);
            mockIngredientRepository.Verify(repo => repo.AddAsync(createdIngredient), Times.Once);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(CancellationToken.None), Times.Once);
        }
         
    }
}
