using System;
using Xunit;
using NutritionalKitchen.Domain.Package;

namespace NutritionalKitchen.Test
{
    public class LabelTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties_WhenValidData()
        {
            // Arrange
            var batchCode = Guid.NewGuid();
            var productionDate = DateTime.Now;
            var expirationDate = productionDate.AddDays(30);
            var detail = "Package Detail";
            var address = "123 Kitchen Ave.";
            var patientId = Guid.NewGuid();

            // Act
            var label = new Label(batchCode, productionDate, expirationDate, detail, address, patientId);

            // Assert
            Assert.Equal(batchCode, label.BatchCode); 
            Assert.Equal(address, label.Address);
            Assert.Equal(patientId, label.PatientId);
        }

        [Fact]
        public void UpdateDetail_ShouldUpdate_WhenValidDetail()
        {
            // Arrange
            var label = new Label(Guid.NewGuid(), DateTime.Now, DateTime.Now.AddDays(30), "Detail", "Address", Guid.NewGuid());
            var newDetail = "Updated Detail";

            // Act
            label.UpdateDetail(newDetail);

            // Assert
            Assert.Equal(newDetail, label.Detail);
        }

        [Fact]
        public void UpdateDetail_ShouldThrowException_WhenDetailIsEmpty()
        {
            // Arrange
            var label = new Label(Guid.NewGuid(), DateTime.Now, DateTime.Now.AddDays(30), "Detail", "Address", Guid.NewGuid());

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => label.UpdateDetail(""));
            Assert.Equal("El detalle no puede estar vacío.", exception.Message);
        }

        [Fact]
        public void UpdateAddress_ShouldUpdate_WhenValidAddress()
        {
            // Arrange
            var label = new Label(Guid.NewGuid(), DateTime.Now, DateTime.Now.AddDays(30), "Detail", "Old Address", Guid.NewGuid());
            var newAddress = "New Address";

            // Act
            label.UpdateAddress(newAddress);

            // Assert
            Assert.Equal(newAddress, label.Address);
        }

        [Fact]
        public void UpdateAddress_ShouldThrowException_WhenAddressIsEmpty()
        {
            // Arrange
            var label = new Label(Guid.NewGuid(), DateTime.Now, DateTime.Now.AddDays(30), "Detail", "Address", Guid.NewGuid());

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => label.UpdateAddress(""));
            Assert.Equal("La dirección no puede estar vacía.", exception.Message);
        }

        [Fact]
        public void UpdateDates_ShouldUpdate_WhenDatesAreValid()
        {
            // Arrange
            var label = new Label(Guid.NewGuid(), DateTime.Now, DateTime.Now.AddDays(30), "Detail", "Address", Guid.NewGuid());
            var newProductionDate = DateTime.Now.AddDays(5);
            var newExpirationDate = newProductionDate.AddDays(20);

            // Act
            label.UpdateDates(newProductionDate, newExpirationDate);

            // Assert
            Assert.Equal(newProductionDate, label.ProductionDate);
            Assert.Equal(newExpirationDate, label.ExpirationDate);
        }

        [Fact]
        public void UpdateDates_ShouldThrowException_WhenExpirationDateIsBeforeProductionDate()
        {
            // Arrange
            var label = new Label(Guid.NewGuid(), DateTime.Now, DateTime.Now.AddDays(30), "Detail", "Address", Guid.NewGuid());
            var newProductionDate = DateTime.Now;
            var newExpirationDate = newProductionDate.AddDays(-1);

            // Assert
            var exception = Assert.Throws<ArgumentException>(() => label.UpdateDates(newProductionDate, newExpirationDate));
            Assert.Equal("La fecha de expiración debe ser posterior a la fecha de producción.", exception.Message);
        }
    }


}
