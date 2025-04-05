using NutritionalKitchen.Domain.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Domain.Recipe
{
    public class IngredientRecipeFactoryTest
    {
        private readonly IngredientRecipeFactory _factory;

        public IngredientRecipeFactoryTest()
        {
            _factory = new IngredientRecipeFactory();
        }

        [Fact]
        public void Create_ShouldThrowException_WhenIdIsEmpty()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                _factory.Create(Guid.Empty, 10, "grams", Guid.NewGuid(), Guid.NewGuid()));

            Assert.Equal("Id is required (Parameter 'id')", exception.Message);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenQuantityIsZeroOrNegative()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                _factory.Create(Guid.NewGuid(), 0, "grams", Guid.NewGuid(), Guid.NewGuid()));

            Assert.Equal("Quantity must be greater than zero (Parameter 'quantity')", exception.Message);

            exception = Assert.Throws<ArgumentException>(() =>
                _factory.Create(Guid.NewGuid(), -5, "grams", Guid.NewGuid(), Guid.NewGuid()));

            Assert.Equal("Quantity must be greater than zero (Parameter 'quantity')", exception.Message);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenMeasureUnitIsNullOrWhitespace()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                _factory.Create(Guid.NewGuid(), 10, "", Guid.NewGuid(), Guid.NewGuid()));

            Assert.Equal("Measure unit is required (Parameter 'measureUnit')", exception.Message);

            exception = Assert.Throws<ArgumentException>(() =>
                _factory.Create(Guid.NewGuid(), 10, "   ", Guid.NewGuid(), Guid.NewGuid()));

            Assert.Equal("Measure unit is required (Parameter 'measureUnit')", exception.Message);

            exception = Assert.Throws<ArgumentException>(() =>
                _factory.Create(Guid.NewGuid(), 10, null, Guid.NewGuid(), Guid.NewGuid()));

            Assert.Equal("Measure unit is required (Parameter 'measureUnit')", exception.Message);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenRecipeIdIsEmpty()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                _factory.Create(Guid.NewGuid(), 10, "grams", Guid.Empty, Guid.NewGuid()));

            Assert.Equal("Recipe ID is required (Parameter 'recipeId')", exception.Message);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenIngredientIdIsEmpty()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                _factory.Create(Guid.NewGuid(), 10, "grams", Guid.NewGuid(), Guid.Empty));

            Assert.Equal("Ingredient ID is required (Parameter 'ingredientId')", exception.Message);
        }

        [Fact]
        public void Create_ShouldReturnIngredientRecipe_WhenValidParametersAreProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            var quantity = 100;
            var measureUnit = "grams";
            var recipeId = Guid.NewGuid();
            var ingredientId = Guid.NewGuid();

            // Act
            var ingredientRecipe = _factory.Create(id, quantity, measureUnit, recipeId, ingredientId);

            // Assert
            Assert.NotNull(ingredientRecipe);
            Assert.Equal(id, ingredientRecipe.Id);
            Assert.Equal(quantity, ingredientRecipe.Quantity);
            Assert.Equal(measureUnit, ingredientRecipe.MeasureUnit);
            Assert.Equal(recipeId, ingredientRecipe.RecipeId);
            Assert.Equal(ingredientId, ingredientRecipe.IngredientId);
        }
    }
}
