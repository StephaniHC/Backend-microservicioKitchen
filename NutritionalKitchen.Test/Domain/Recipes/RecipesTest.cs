using NutritionalKitchen.Domain.Recipe;
using NutritionalKitchen.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit; 
 
namespace NutritionalKitchen.Test.Domain.Recipe
{
    public class RecipesTest
    {
        [Fact]
        public void Constructor_ShouldCreateInstance_WhenValidParameters()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Spaghetti Bolognese";
            var preparationTime = "30 minutes";

            // Act
            var recipe = new NutritionalKitchen.Domain.Recipe.Recipe(id, name, preparationTime);

            // Assert
            Assert.NotNull(recipe);
            Assert.Equal(id, recipe.Id);
            Assert.Equal(name, recipe.Name);
            Assert.Equal(preparationTime, recipe.PreparationTime);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void UpdateName_ShouldThrowException_WhenInvalidName(string invalidName)
        {
            // Arrange
            var recipe = new NutritionalKitchen.Domain.Recipe.Recipe(Guid.NewGuid(), "Original Name", "30 minutes");

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => recipe.UpdateName(invalidName));
            Assert.Equal("El nombre no puede estar vacío.", exception.Message);
        }

        [Fact]
        public void UpdateName_ShouldUpdateValue_WhenValidName()
        {
            // Arrange
            var recipe = new NutritionalKitchen.Domain.Recipe.Recipe(Guid.NewGuid(), "Old Name", "30 minutes");
            var newName = "New Recipe Name";

            // Act
            recipe.UpdateName(newName);

            // Assert
            Assert.Equal(newName, recipe.Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void UpdatePreparationTime_ShouldThrowException_WhenInvalidPreparationTime(string invalidTime)
        {
            // Arrange
            var recipe = new NutritionalKitchen.Domain.Recipe.Recipe(Guid.NewGuid(), "Recipe Name", "30 minutes");

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => recipe.UpdatePreparationTime(invalidTime));
            Assert.Equal("El tiempo de preparación no puede estar vacío.", exception.Message);
        }

        [Fact]
        public void UpdatePreparationTime_ShouldUpdateValue_WhenValidPreparationTime()
        {
            // Arrange
            var recipe = new NutritionalKitchen.Domain.Recipe.Recipe(Guid.NewGuid(), "Recipe Name", "30 minutes");
            var newPreparationTime = "45 minutes";

            // Act
            recipe.UpdatePreparationTime(newPreparationTime);

            // Assert
            Assert.Equal(newPreparationTime, recipe.PreparationTime);
        }
    }
}
