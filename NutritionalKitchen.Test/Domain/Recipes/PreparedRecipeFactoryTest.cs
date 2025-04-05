using NutritionalKitchen.Domain.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Domain.Recipe
{
    public class PreparedRecipeFactoryTest
    {
        private readonly PreparedRecipeFactory _factory;

        public PreparedRecipeFactoryTest()
        {
            _factory = new PreparedRecipeFactory();
        }

        [Fact]
        public void Create_ShouldThrowException_WhenIdIsEmpty()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                _factory.Create(Guid.Empty, DateTime.Now, true, Guid.NewGuid(), Guid.NewGuid()));

            Assert.Equal("Id is required (Parameter 'id')", exception.Message);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenDateIsDefault()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                _factory.Create(Guid.NewGuid(), default, true, Guid.NewGuid(), Guid.NewGuid()));

            Assert.Equal("Date is required (Parameter 'date')", exception.Message);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenKitchenManagerIdIsEmpty()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                _factory.Create(Guid.NewGuid(), DateTime.Now, true, Guid.Empty, Guid.NewGuid()));

            Assert.Equal("Kitchen manager ID is required (Parameter 'kitchenManagerId')", exception.Message);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenRecipeIdIsEmpty()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                _factory.Create(Guid.NewGuid(), DateTime.Now, true, Guid.NewGuid(), Guid.Empty));

            Assert.Equal("Recipe ID is required (Parameter 'recipeId')", exception.Message);
        }

        [Fact]
        public void Create_ShouldReturnPreparedRecipe_WhenValidParametersAreProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            var date = DateTime.Now;
            var status = true;
            var kitchenManagerId = Guid.NewGuid();
            var recipeId = Guid.NewGuid();

            // Act
            var preparedRecipe = _factory.Create(id, date, status, kitchenManagerId, recipeId);

            // Assert
            Assert.NotNull(preparedRecipe);
            Assert.Equal(id, preparedRecipe.Id);
            Assert.Equal(date, preparedRecipe.Date);
            Assert.Equal(status, preparedRecipe.Status);
            Assert.Equal(kitchenManagerId, preparedRecipe.KitchenManagerId);
            Assert.Equal(recipeId, preparedRecipe.RecipeId);
        }
    }
}
