using NutritionalKitchen.Domain.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Domain.Package
{
    public class LabelFactoryTests
    {
        private readonly ILabelFactory _factory;

        public LabelFactoryTests()
        {
            _factory = new LabelFactory(); // Suponiendo que hay una implementación concreta de ILabelFactory
        }

        [Fact]
        public void Create_ShouldReturnLabel_WhenValidParameters()
        {
            // Arrange
            var batchCode = Guid.NewGuid();
            var productionDate = DateTime.Now;
            var expirationDate = productionDate.AddDays(30);
            var detail = "Valid Detail";
            var address = "Valid Address";
            var patientId = Guid.NewGuid();

            // Act
            var label = _factory.Create(batchCode, productionDate, expirationDate, detail, address, patientId);

            // Assert
            Assert.NotNull(label);
            Assert.Equal(batchCode, label.BatchCode);
            Assert.Equal(productionDate, label.ProductionDate);
            Assert.Equal(expirationDate, label.ExpirationDate);
            Assert.Equal(detail, label.Detail);
            Assert.Equal(address, label.Address);
            Assert.Equal(patientId, label.PatientId);
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000", "2024-02-01", "2024-03-01", "Detail", "Address", "ValidId", "Batch code is required")]
        [InlineData("ValidId", "0001-01-01", "2024-03-01", "Detail", "Address", "ValidId", "Production date is required")]
        [InlineData("ValidId", "2024-02-01", "0001-01-01", "Detail", "Address", "ValidId", "Expiration date is required")]
        [InlineData("ValidId", "2024-02-01", "2024-03-01", "Detail", "Address", "00000000-0000-0000-0000-000000000000", "Patient ID is required")]
        public void Create_ShouldThrowException_WhenInvalidParameters(
            string batchCodeStr, string productionDateStr, string expirationDateStr,
            string detail, string address, string patientIdStr, string expectedMessage)
        {
            // Arrange
            var batchCode = Guid.TryParse(batchCodeStr, out var bc) ? bc : Guid.NewGuid();
            var productionDate = DateTime.TryParse(productionDateStr, out var pd) ? pd : DateTime.Now;
            var expirationDate = DateTime.TryParse(expirationDateStr, out var ed) ? ed : DateTime.Now.AddDays(30);
            var patientId = Guid.TryParse(patientIdStr, out var pi) ? pi : Guid.NewGuid();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                _factory.Create(batchCode, productionDate, expirationDate, detail, address, patientId)
            );

            Assert.Contains(expectedMessage, exception.Message); 
        }
    }
}
