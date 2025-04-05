using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NutritionalKitchen.Application.Recipe.GetRecipe;
using NutritionalKitchen.Domain.Recipe;
using NutritionalKitchen.Infraestructura.Handlers;
using NutritionalKitchen.Infraestructura.StoredModel;
using NutritionalKitchen.Infraestructura.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Infraestructura.Handler
{
    public class GetRecipeHandlerTest
    {
        private readonly Mock<StoredDbContext> _dbContext;

        public GetRecipeHandlerTest()
        {
            var options = new DbContextOptions<StoredDbContext>();
            _dbContext = new Mock<StoredDbContext>(options);
        }

        [Fact]
        public async Task Handle_ShouldReturnRecipes()
        {
            // Arrange
            var recipes = new List<RecipeStoredModel>
            {
                new RecipeStoredModel { Id = Guid.NewGuid(), Name = "Spaghetti", PreparationTime = "30" },
                new RecipeStoredModel { Id = Guid.NewGuid(), Name = "Salad", PreparationTime = "15" }
            };

            // Configurar el DbContext simulado con Moq.EntityFrameworkCore
            _dbContext.Setup(x => x.Recipe).ReturnsDbSet(recipes);

            var handler = new GetRecipeHandler(_dbContext.Object);
            var query = new GetRecipeQuery(""); 
            var cancellationToken = new CancellationTokenSource(1000).Token;

            // Act
            var result = await handler.Handle(query, cancellationToken);

            // Assert
            Assert.NotNull(result);
            var resultList = result.ToList();
            Assert.Equal(2, resultList.Count);
            Assert.Equal("Spaghetti", resultList[0].Name);
            Assert.Equal("Salad", resultList[1].Name); 
        }
    }
}
