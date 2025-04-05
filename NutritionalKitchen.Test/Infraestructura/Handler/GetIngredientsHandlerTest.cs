using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NutritionalKitchen.Application.Ingredients.GetIngredients;
using NutritionalKitchen.Domain.Ingredients;
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
    public class GetIngredientsHandlerTest
    {
        private readonly Mock<StoredDbContext> _dbContext;

        public GetIngredientsHandlerTest()
        {
            var options = new DbContextOptions<StoredDbContext>();
            _dbContext = new Mock<StoredDbContext>(options);
        }

        [Fact]
        public async Task HandleIsValid()
        {

            // Arrange
            var ingredients = new List<IngredientsStoredModel>
            {
                new IngredientsStoredModel { Id = Guid.NewGuid(), Name = "Tomato" },
                new IngredientsStoredModel { Id = Guid.NewGuid(), Name = "Carrot" }
            };

            // Configurar el DbContext simulado con Moq.EntityFrameworkCore
            _dbContext.Setup(x => x.Ingredients).ReturnsDbSet(ingredients);

            var handler = new GetIngredientsHandler(_dbContext.Object);
            var tcs = new CancellationTokenSource(1000);
            // Act
            var result = await handler.Handle(new GetIngredientsQuery(""), tcs.Token);

            // Assert
            Assert.NotNull(result);
            var resultList = result.ToList();
            Assert.Equal(2, resultList.Count);
            Assert.Equal("Tomato", resultList[0].Name);
            Assert.Equal("Carrot", resultList[1].Name);
        }
    }
}
