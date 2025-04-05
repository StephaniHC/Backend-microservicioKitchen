using NutritionalKitchen.Domain.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Domain.Recipe
{
    public class PreparedRecipeTest
    {
        [Fact]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();
            var date = DateTime.UtcNow;
            var status = true;
            var kitchenManagerId = Guid.NewGuid();
            var recipeId = Guid.NewGuid();

            // Act
            var preparedRecipe = new PreparedRecipe(id, date, status, kitchenManagerId, recipeId);

            // Assert
            Assert.Equal(id, preparedRecipe.Id);
            Assert.Equal(date, preparedRecipe.Date);
            Assert.Equal(status, preparedRecipe.Status);
            Assert.Equal(kitchenManagerId, preparedRecipe.KitchenManagerId);
            Assert.Equal(recipeId, preparedRecipe.RecipeId);
        }

        [Fact]
        public void UpdateStatus_ShouldChangeStatus()
        {
            // Arrange
            var preparedRecipe = new PreparedRecipe(Guid.NewGuid(), DateTime.UtcNow, false, Guid.NewGuid(), Guid.NewGuid());

            // Act
            preparedRecipe.UpdateStatus(true);

            // Assert
            Assert.True(preparedRecipe.Status);
        }

        [Fact]
        public void UpdateDate_ShouldChangeDate_WhenValidDateIsProvided()
        {
            // Arrange
            var preparedRecipe = new PreparedRecipe(Guid.NewGuid(), DateTime.UtcNow.AddDays(-1), true, Guid.NewGuid(), Guid.NewGuid());
            var newDate = DateTime.UtcNow.AddHours(-1);

            // Act
            preparedRecipe.UpdateDate(newDate);

            // Assert
            Assert.Equal(newDate, preparedRecipe.Date);
        }

        [Fact]
        public void UpdateDate_ShouldThrowException_WhenDateIsInTheFuture()
        {
            // Arrange
            var preparedRecipe = new PreparedRecipe(Guid.NewGuid(), DateTime.UtcNow, true, Guid.NewGuid(), Guid.NewGuid());
            var futureDate = DateTime.UtcNow.AddDays(1);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => preparedRecipe.UpdateDate(futureDate));
            Assert.Equal("La fecha no puede estar en el futuro.", exception.Message);
        }
    }
}
