using NutritionalKitchen.Domain.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace NutritionalKitchen.Test.Domain.Ingredients
{
    public class IngredientFactoryTests
    {
        [Fact]
        public void Create_ShouldThrowException_WhenIdIsEmpty()
        {
            // Arrange
            var factory = new IngredientFactory();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => factory.Create(Guid.Empty, "Ingredient Name"));
            Assert.Equal("Id is required (Parameter 'id')", exception.Message);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenNameIsNullOrWhitespace()
        {
            // Arrange
            var factory = new IngredientFactory();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => factory.Create(Guid.NewGuid(), ""));
            Assert.Equal("Ingredient name is required (Parameter 'name')", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => factory.Create(Guid.NewGuid(), null));
            Assert.Equal("Ingredient name is required (Parameter 'name')", exception.Message);
        }

        [Fact]
        public void Create_ShouldCreateIngredient_WhenValidArguments()
        {
            // Arrange
            var factory = new IngredientFactory();
            var id = Guid.NewGuid();
            var name = "Ingredient Name";

            // Act
            var ingredient = factory.Create(id, name);

            // Assert
            Assert.NotNull(ingredient);
            Assert.Equal(id, ingredient.Id);
            Assert.Equal(name, ingredient.Name);
        }
    } 
}
