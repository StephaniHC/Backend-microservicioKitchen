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
    public class LabelStoredModelTest
    { 
        [Fact]
        public void LabelStoredModel_Should_Have_Valid_ProductionDate()
        {
            var label = new LabelStoredModel
            {
                BatchCode = Guid.NewGuid(),
                ProductionDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(30),
                PatientId = Guid.NewGuid()
            };

            Assert.True(label.ProductionDate <= label.ExpirationDate);
        }

        [Fact]
        public void LabelStoredModel_Should_Have_Valid_Address_When_Empty()
        {
            var label = new LabelStoredModel
            {
                BatchCode = Guid.NewGuid(),
                ProductionDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(30),
                PatientId = Guid.NewGuid(),
                Detail = "Valid detail text",
                Address = string.Empty  
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(label, serviceProvider: null, items: null);
            bool isValid = Validator.TryValidateObject(label, validationContext, validationResults, true);

            Assert.True(isValid);
        }

        [Fact]
        public void LabelStoredModel_Should_Have_Valid_Detail_When_Empty()
        {
            var label = new LabelStoredModel
            {
                BatchCode = Guid.NewGuid(),
                ProductionDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(30),
                PatientId = Guid.NewGuid(),
                Detail = string.Empty,   
                Address = "Valid address"
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(label, serviceProvider: null, items: null);
            bool isValid = Validator.TryValidateObject(label, validationContext, validationResults, true);

            Assert.True(isValid);
        }

        [Fact]
        public void LabelStoredModel_Should_Have_Invalid_Address_When_Length_Is_Greater_Than_250()
        {
            var label = new LabelStoredModel
            {
                BatchCode = Guid.NewGuid(),
                ProductionDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(30),
                PatientId = Guid.NewGuid(),
                Detail = "Valid detail text",
                Address = new string('A', 251) 
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(label, serviceProvider: null, items: null);
            bool isValid = Validator.TryValidateObject(label, validationContext, validationResults, true);

            Assert.False(isValid);
        }

        [Fact]
        public void LabelStoredModel_Should_Have_Valid_Address_When_Length_Is_Less_Than_250()
        {
            var label = new LabelStoredModel
            {
                BatchCode = Guid.NewGuid(),
                ProductionDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(30),
                PatientId = Guid.NewGuid(),
                Detail = "Valid detail text",
                Address = new string('A', 249)  
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(label, serviceProvider: null, items: null);
            bool isValid = Validator.TryValidateObject(label, validationContext, validationResults, true);

            Assert.True(isValid);
        }

        [Fact]
        public void LabelStoredModel_Should_Have_Invalid_Detail_When_Length_Is_Greater_Than_500()
        {
            var label = new LabelStoredModel
            {
                BatchCode = Guid.NewGuid(),
                ProductionDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(30),
                PatientId = Guid.NewGuid(),
                Detail = new string('A', 501), 
                Address = "Valid address"
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(label, serviceProvider: null, items: null);
            bool isValid = Validator.TryValidateObject(label, validationContext, validationResults, true);

            Assert.False(isValid);
        }
    }
}
