using NutritionalKitchen.Domain.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Domain.Recipe
{
    public class IngredientRecipeTest
    {
        [Fact]
        public void Constructor_ShouldThrowException_WhenIdIsEmpty()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new IngredientRecipe(Guid.Empty, 10, "kg", Guid.NewGuid(), Guid.NewGuid()));
            Assert.Equal("El Id no puede estar vacío (Parameter 'id')", exception.Message);
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenQuantityIsZeroOrNegative()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new IngredientRecipe(Guid.NewGuid(), 0, "kg", Guid.NewGuid(), Guid.NewGuid()));
            Assert.Equal("La cantidad debe ser mayor que cero (Parameter 'quantity')", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => new IngredientRecipe(Guid.NewGuid(), -1, "kg", Guid.NewGuid(), Guid.NewGuid()));
            Assert.Equal("La cantidad debe ser mayor que cero (Parameter 'quantity')", exception.Message);
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenMeasureUnitIsNullOrWhitespace()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new IngredientRecipe(Guid.NewGuid(), 10, "", Guid.NewGuid(), Guid.NewGuid()));
            Assert.Equal("La unidad de medida no puede estar vacía. (Parameter 'measureUnit')", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => new IngredientRecipe(Guid.NewGuid(), 10, null, Guid.NewGuid(), Guid.NewGuid()));
            Assert.Equal("La unidad de medida no puede estar vacía. (Parameter 'measureUnit')", exception.Message);
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenRecipeIdIsEmpty()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new IngredientRecipe(Guid.NewGuid(), 10, "kg", Guid.Empty, Guid.NewGuid()));
            Assert.Equal("El Id de la receta no puede estar vacío (Parameter 'recipeId')", exception.Message);
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenIngredientIdIsEmpty()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new IngredientRecipe(Guid.NewGuid(), 10, "kg", Guid.NewGuid(), Guid.Empty));
            Assert.Equal("El Id del ingrediente no puede estar vacío (Parameter 'ingredientId')", exception.Message);
        }

        [Fact]
        public void Constructor_ShouldInitializeProperties_WhenValidArguments()
        {
            // Arrange
            var id = Guid.NewGuid();
            var quantity = 10;
            var measureUnit = "kg";
            var recipeId = Guid.NewGuid();
            var ingredientId = Guid.NewGuid();

            // Act
            var ingredientRecipe = new IngredientRecipe(id, quantity, measureUnit, recipeId, ingredientId);

            // Assert
            Assert.Equal(id, ingredientRecipe.Id);
            Assert.Equal(quantity, ingredientRecipe.Quantity);
            Assert.Equal(measureUnit, ingredientRecipe.MeasureUnit);
            Assert.Equal(recipeId, ingredientRecipe.RecipeId);
            Assert.Equal(ingredientId, ingredientRecipe.IngredientId);
        }

        [Fact]
        public void UpdateQuantity_ShouldThrowException_WhenNewQuantityIsZeroOrNegative()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new IngredientRecipe(Guid.NewGuid(), 10, "kg", Guid.NewGuid(), Guid.NewGuid()).UpdateQuantity(0));
            Assert.Equal("La cantidad debe ser mayor que cero. (Parameter 'newQuantity')", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => new IngredientRecipe(Guid.NewGuid(), 10, "kg", Guid.NewGuid(), Guid.NewGuid()).UpdateQuantity(-1));
            Assert.Equal("La cantidad debe ser mayor que cero. (Parameter 'newQuantity')", exception.Message);
        }

        [Fact]
        public void UpdateQuantity_ShouldUpdateQuantity_WhenNewQuantityIsValid()
        {
            // Arrange
            var ingredientRecipe = new IngredientRecipe(Guid.NewGuid(), 10, "kg", Guid.NewGuid(), Guid.NewGuid());

            // Act
            ingredientRecipe.UpdateQuantity(20);

            // Assert
            Assert.Equal(20, ingredientRecipe.Quantity);
        }  

        [Fact]
        public void UpdateMeasureUnit_ShouldThrowException_WhenNewMeasureUnitIsNullOrWhitespace()
        {
            // Arrange
            var ingredientRecipe = new IngredientRecipe(Guid.NewGuid(), 10, "kg", Guid.NewGuid(), Guid.NewGuid());

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => ingredientRecipe.UpdateMeasureUnit(""));
            Assert.Equal("La unidad de medida no puede estar vacía. (Parameter 'measureUnit')", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => ingredientRecipe.UpdateMeasureUnit(null));
            Assert.Equal("La unidad de medida no puede estar vacía. (Parameter 'measureUnit')", exception.Message);
        }

        [Fact]
        public void UpdateMeasureUnit_ShouldUpdateMeasureUnit_WhenNewMeasureUnitIsValid()
        {
            // Arrange
            var ingredientRecipe = new IngredientRecipe(Guid.NewGuid(), 10, "kg", Guid.NewGuid(), Guid.NewGuid());

            // Act
            ingredientRecipe.UpdateMeasureUnit("lb");

            // Assert
            Assert.Equal("lb", ingredientRecipe.MeasureUnit);
        }


    }
}
