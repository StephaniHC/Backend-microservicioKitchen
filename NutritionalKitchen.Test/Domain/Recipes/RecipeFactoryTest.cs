using NutritionalKitchen.Domain.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Domain.Recipe
{
    public class RecipeFactoryTest
    {
        private readonly RecipeFactory _factory;

        public RecipeFactoryTest()
        {
            _factory = new RecipeFactory();
        }

        [Fact]
        public void Create_ShouldReturnRecipe_WhenValidParametersAreProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Spaghetti Bolognese";
            var preparationTime = "30 minutes";

            // Act
            var recipe = _factory.Create(id, name, preparationTime);

            // Assert
            Assert.NotNull(recipe);
            Assert.Equal(id, recipe.Id);
            Assert.Equal(name, recipe.Name);
            Assert.Equal(preparationTime, recipe.PreparationTime);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenIdIsEmpty()
        {
            // Arrange
            var name = "Spaghetti Bolognese";
            var preparationTime = "30 minutes";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _factory.Create(Guid.Empty, name, preparationTime));
            Assert.Equal("Id is required (Parameter 'id')", exception.Message);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenNameIsNullOrWhitespace()
        {
            // Arrange
            var id = Guid.NewGuid();
            var preparationTime = "30 minutes";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _factory.Create(id, "", preparationTime));
            Assert.Equal("Recipe name is required (Parameter 'name')", exception.Message);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenPreparationTimeIsNullOrWhitespace()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Spaghetti Bolognese";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _factory.Create(id, name, "  "));
            Assert.Equal("Preparation time is required (Parameter 'preparationTime')", exception.Message);
        }
    }
}
