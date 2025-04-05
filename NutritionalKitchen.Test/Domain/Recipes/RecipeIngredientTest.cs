using NutritionalKitchen.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Domain.Recipe
{
    public class RecipeIngredientTest
    {
        [Fact]
        public void Constructor_ShouldCreateInstance_WhenValidParameters()
        {
            // Arrange
            var quantity = new QuantityValue(10);
            var unitOfMeasure = "grams";
            var recipeId = Guid.NewGuid();
            var ingredientId = Guid.NewGuid();

            // Act
            var recipeIngredient = new RecipeIngredient(quantity.Value, unitOfMeasure, recipeId, ingredientId);

            // Assert
            Assert.Equal(quantity.Value, recipeIngredient.Quantity.Value);
            Assert.Equal(unitOfMeasure, recipeIngredient.UnitOfMeasure);
            Assert.Equal(recipeId, recipeIngredient.RecipeId);
            Assert.Equal(ingredientId, recipeIngredient.IngredientId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void UpdateQuantity_ShouldThrowException_WhenInvalidValue(double invalidQuantity)
        {
            // Arrange
            var recipeIngredient = new RecipeIngredient(10, "grams", Guid.NewGuid(), Guid.NewGuid());

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => recipeIngredient.UpdateQuantity(new QuantityValue(invalidQuantity)));
            Assert.Equal("La cantidad debe ser mayor a cero. (Parameter 'value')", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void UpdateUnitOfMeasure_ShouldThrowException_WhenInvalidValue(string invalidUnitOfMeasure)
        {
            // Arrange
            var recipeIngredient = new RecipeIngredient(10, "grams", Guid.NewGuid(), Guid.NewGuid());

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => recipeIngredient.UpdateUnitOfMeasure(invalidUnitOfMeasure));
            Assert.Equal("La unidad de medida no puede estar vacía.", exception.Message);
        }

        [Fact]
        public void UpdateQuantity_ShouldUpdateValue_WhenValidQuantity()
        {
            // Arrange
            var recipeIngredient = new RecipeIngredient(10, "grams", Guid.NewGuid(), Guid.NewGuid());
            var newQuantity = new QuantityValue(20);

            // Act
            recipeIngredient.UpdateQuantity(newQuantity);

            // Assert
            Assert.Equal(newQuantity.Value, recipeIngredient.Quantity.Value);
        }

        [Fact]
        public void UpdateUnitOfMeasure_ShouldUpdateValue_WhenValidValue()
        {
            // Arrange
            var recipeIngredient = new RecipeIngredient(10, "grams", Guid.NewGuid(), Guid.NewGuid());
            var newUnitOfMeasure = "kg";

            // Act
            recipeIngredient.UpdateUnitOfMeasure(newUnitOfMeasure);

            // Assert
            Assert.Equal(newUnitOfMeasure, recipeIngredient.UnitOfMeasure);
        }
        [Fact]
        public void Constructor_ShouldThrowException_WhenQuantityIsNull()
        {
            // Arrange
            QuantityValue nullQuantity = null;
            string unitOfMeasure = "kg";
            Guid recipeId = Guid.NewGuid();
            Guid ingredientId = Guid.NewGuid();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new RecipeIngredient(nullQuantity, unitOfMeasure, recipeId, ingredientId));
            Assert.Equal("La cantidad no puede ser nula. (Parameter 'quantity')", exception.Message);
        } 
         

        [Fact]
        public void UpdateQuantity_ShouldUpdateQuantity_WhenValidQuantity()
        {
            // Arrange
            var initialQuantity = new QuantityValue(10);
            var recipeIngredient = new RecipeIngredient(initialQuantity, "kg", Guid.NewGuid(), Guid.NewGuid());
            var newQuantity = new QuantityValue(15);

            // Act
            recipeIngredient.UpdateQuantity(newQuantity);

            // Assert
            Assert.Equal(newQuantity, recipeIngredient.Quantity);
        }
    }
}
