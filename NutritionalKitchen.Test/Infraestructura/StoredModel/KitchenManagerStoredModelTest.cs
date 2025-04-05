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
    public class KitchenManagerStoredModelTest
    {
        [Fact]
        public void KitchenManager_ShouldFailValidation_WhenNameIsNull()
        {
            // Arrange
            var kitchenManager = new KitchenManagerStoredModel
            {
                Id = Guid.NewGuid(),
                Name = null,
                Shift = "Morning"
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(kitchenManager, null, null);
            var isValid = Validator.TryValidateObject(kitchenManager, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid); // Expecting validation to fail
            Assert.Contains(validationResults, vr => vr.MemberNames.Contains("Name"));
        }

        [Fact]
        public void KitchenManager_ShouldFailValidation_WhenShiftIsNull()
        {
            // Arrange
            var kitchenManager = new KitchenManagerStoredModel
            {
                Id = Guid.NewGuid(),
                Name = "John Doe",
                Shift = null
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(kitchenManager, null, null);
            var isValid = Validator.TryValidateObject(kitchenManager, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid); // Expecting validation to fail
            Assert.Contains(validationResults, vr => vr.MemberNames.Contains("Shift"));
        }

        [Fact]
        public void KitchenManager_ShouldFailValidation_WhenNameIsTooLong()
        {
            // Arrange
            var kitchenManager = new KitchenManagerStoredModel
            {
                Id = Guid.NewGuid(),
                Name = new string('A', 251), // Name exceeds 250 characters
                Shift = "Morning"
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(kitchenManager, null, null);
            var isValid = Validator.TryValidateObject(kitchenManager, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid); // Expecting validation to fail
            Assert.Contains(validationResults, vr => vr.MemberNames.Contains("Name"));
        }

        [Fact]
        public void KitchenManager_ShouldPassValidation_WhenPropertiesAreValid()
        {
            // Arrange
            var kitchenManager = new KitchenManagerStoredModel
            {
                Id = Guid.NewGuid(),
                Name = "John Doe",
                Shift = "Morning"
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(kitchenManager, null, null);
            var isValid = Validator.TryValidateObject(kitchenManager, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid); // Expecting validation to pass
        }
    }
}
