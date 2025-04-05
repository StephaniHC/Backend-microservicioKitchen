using Moq;
using NutritionalKitchen.Application.Recipe.CreateRecipe;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit; 

namespace NutritionalKitchen.Test.Application.Recipe
{
    public class CreateCommandHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldCreateRecipe_AndReturnRecipeId_WhenValidRequest()
        {
            // Arrange
            var recipeId = Guid.NewGuid();
            var recipeName = "Pasta Primavera";
            var preparationTime = "30";
            var command = new CreateRecipeCommand(recipeId, recipeName, preparationTime);

            // Mock de las dependencias
            var mockRecipeFactory = new Mock<IRecipeFactory>();
            var mockRecipeRepository = new Mock<IRecipeRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            // Creamos un objeto ficticio de receta
            var createdRecipe = new NutritionalKitchen.Domain.Recipe.Recipe(recipeId, recipeName, preparationTime);

            // Configuramos los mocks
            mockRecipeFactory
                .Setup(factory => factory.Create(recipeId, recipeName, preparationTime))
                .Returns(createdRecipe);

            mockRecipeRepository
                .Setup(repo => repo.AddAsync(It.IsAny<NutritionalKitchen.Domain.Recipe.Recipe>()))
                .Returns(Task.CompletedTask);

            mockUnitOfWork
                .Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Creamos el handler
            var handler = new CreateCommandHandler(
                mockRecipeFactory.Object,
                mockRecipeRepository.Object,
                mockUnitOfWork.Object
            );

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(recipeId, result);

            // Verificar que los métodos de las dependencias se llamaron una vez
            mockRecipeFactory.Verify(factory => factory.Create(recipeId, recipeName, preparationTime), Times.Once);
            mockRecipeRepository.Verify(repo => repo.AddAsync(It.IsAny<NutritionalKitchen.Domain.Recipe.Recipe>()), Times.Once);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(CancellationToken.None), Times.Once);
        }
    }
} 