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
    public class PackageStoredModelTest
    { 

        [Fact]
        public void PackageStoredModel_ShouldFailValidation_WhenStatusIsNull()
        {
            // Arrange
            var package = new PackageStoredModel
            {
                Id = Guid.NewGuid(),
                Status = null,  
                BatchCode = "12345",
                PreparedRecipeId = Guid.NewGuid()
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(package, null, null);
            var isValid = Validator.TryValidateObject(package, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid); 
            Assert.Contains(validationResults, vr => vr.MemberNames.Contains("Status"));
        }

        [Fact]
        public void PackageStoredModel_ShouldFailValidation_WhenBatchCodeIsNull()
        {
            // Arrange
            var package = new PackageStoredModel
            {
                Id = Guid.NewGuid(),
                Status = "Active",
                BatchCode = null,  
                PreparedRecipeId = Guid.NewGuid()
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(package, null, null);
            var isValid = Validator.TryValidateObject(package, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid); 
            Assert.Contains(validationResults, vr => vr.MemberNames.Contains("BatchCode"));
        }

        [Fact]
        public void PackageStoredModel_ShouldPassValidation_WhenAllPropertiesAreValid()
        {
            // Arrange
            var package = new PackageStoredModel
            {
                Id = Guid.NewGuid(),
                Status = "Active",
                BatchCode = "12345",
                PreparedRecipeId = Guid.NewGuid()
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(package, null, null);
            var isValid = Validator.TryValidateObject(package, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid);  
        }
    }
}
