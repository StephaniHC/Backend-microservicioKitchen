using NutritionalKitchen.Domain.Ingredients;
using System;
using System.Linq;
using System.Text;
using Xunit;


namespace NutritionalKitchen.Test.Domain.Ingredients
{
    public class IngredientsTests
    {
        [Fact]
        public void UpdateName_ShouldUpdateName_WhenValidName()
        {
            // Arrange
            var ingredient = new NutritionalKitchen.Domain.Ingredients.Ingredients(Guid.NewGuid(), "Tomato");
            var newName = "Potato";

            // Act
            ingredient.UpdateName(newName);

            // Assert
            Assert.Equal(newName, ingredient.Name);
        }

        [Fact]
        public void UpdateName_ShouldThrowException_WhenNameIsEmpty()
        {
            // Arrange
            var ingredient = new NutritionalKitchen.Domain.Ingredients.Ingredients(Guid.NewGuid(), "Tomato");


            // Assert
            var exception = Assert.Throws<ArgumentException>(() => ingredient.UpdateName(""));
            Assert.Equal("El nombre del ingrediente no puede estar vacío.", exception.Message);
        }

        [Fact]
        public void Constructor_ShouldSetProperties_WhenValidData()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Tomato";

            // Act
            var ingredient = new NutritionalKitchen.Domain.Ingredients.Ingredients(id, name);

            // Assert
            Assert.Equal(id, ingredient.Id);
            Assert.Equal(name, ingredient.Name);
        }
         
    }
}
