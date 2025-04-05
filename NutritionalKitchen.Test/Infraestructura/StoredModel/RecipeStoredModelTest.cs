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
    public class RecipeStoredModelTest
    { 
        [Fact]
        public void RecipeStoredModel_ShouldFailValidation_WhenNameIsNull()
        {
            // Arrange
            var recipe = new RecipeStoredModel
            {
                Id = Guid.NewGuid(),
                Name = null,  
                PreparationTime = "30 minutes"
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(recipe, null, null);
            var isValid = Validator.TryValidateObject(recipe, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid); 
            Assert.Contains(validationResults, vr => vr.MemberNames.Contains("Name"));
        }

        [Fact]
        public void RecipeStoredModel_ShouldFailValidation_WhenPreparationTimeIsNull()
        {
            // Arrange
            var recipe = new RecipeStoredModel
            {
                Id = Guid.NewGuid(),
                Name = "Recipe 1",
                PreparationTime = null 
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(recipe, null, null);
            var isValid = Validator.TryValidateObject(recipe, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid); 
            Assert.Contains(validationResults, vr => vr.MemberNames.Contains("PreparationTime"));
        }

        [Fact]
        public void RecipeStoredModel_ShouldPassValidation_WhenAllPropertiesAreValid()
        {
            // Arrange
            var recipe = new RecipeStoredModel
            {
                Id = Guid.NewGuid(),
                Name = "Recipe 1",
                PreparationTime = "30 minutes"
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(recipe, null, null);
            var isValid = Validator.TryValidateObject(recipe, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid); 
        }

        [Fact]
        public void RecipeStoredModel_ShouldFailValidation_WhenPreparationTimeExceedsMaxLength()
        {
            // Arrange
            var recipe = new RecipeStoredModel
            {
                Id = Guid.NewGuid(),
                Name = "Recipe 1",
                PreparationTime = new string('a', 51) 
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(recipe, null, null);
            var isValid = Validator.TryValidateObject(recipe, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid); 
            Assert.Contains(validationResults, vr => vr.MemberNames.Contains("PreparationTime"));
        }
    }
}
