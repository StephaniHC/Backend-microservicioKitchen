using NutritionalKitchen.Infraestructura.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Infraestructura.StoredModel
{
    public class IngredientsStoredModelTest
    {
        [Fact]
        public void Ingredient_ShouldFailValidation_WhenNameIsNull()
        {
            // Arrange
            var ingredient = new IngredientsStoredModel
            {
                Id = Guid.NewGuid(),
                Name = null
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(ingredient, null, null);
            var isValid = Validator.TryValidateObject(ingredient, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid); // Expecting validation to fail
            Assert.Contains(validationResults, vr => vr.MemberNames.Contains("Name"));
        }

        [Fact]
        public void Ingredient_ShouldFailValidation_WhenNameIsTooLong()
        {
            // Arrange
            var ingredient = new IngredientsStoredModel
            {
                Id = Guid.NewGuid(),
                Name = new string('A', 251) // Name exceeds 250 characters
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(ingredient, null, null);
            var isValid = Validator.TryValidateObject(ingredient, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid); // Expecting validation to fail
            Assert.Contains(validationResults, vr => vr.MemberNames.Contains("Name"));
        }

        [Fact]
        public void Ingredient_ShouldPassValidation_WhenNameIsValid()
        {
            // Arrange
            var ingredient = new IngredientsStoredModel
            {
                Id = Guid.NewGuid(),
                Name = "Tomato"
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(ingredient, null, null);
            var isValid = Validator.TryValidateObject(ingredient, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid); // Expecting validation to pass
        }
    }
}
