using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NutritionalKitchen.Domain.KitchenManager;
using Xunit;

namespace NutritionalKitchen.Test
{
    public class KitchenManagerFactoryTests
    {
        [Fact]
        public void Create_ShouldThrowException_WhenIdIsEmpty()
        {
            // Arrange
            var factory = new KitchenManagerFactory();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => factory.Create(Guid.Empty, "Manager Name", "Morning"));
            Assert.Equal("Id is required (Parameter 'id')", exception.Message);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenNameIsNullOrWhitespace()
        {
            // Arrange
            var factory = new KitchenManagerFactory();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => factory.Create(Guid.NewGuid(), "", "Morning"));
            Assert.Equal("Name is required (Parameter 'name')", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => factory.Create(Guid.NewGuid(), null, "Morning"));
            Assert.Equal("Name is required (Parameter 'name')", exception.Message);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenShiftIsNullOrWhitespace()
        {
            // Arrange
            var factory = new KitchenManagerFactory();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => factory.Create(Guid.NewGuid(), "Manager Name", ""));
            Assert.Equal("Shift is required (Parameter 'shift')", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => factory.Create(Guid.NewGuid(), "Manager Name", null));
            Assert.Equal("Shift is required (Parameter 'shift')", exception.Message);
        }

        [Fact]
        public void Create_ShouldCreateKitchenManager_WhenValidArguments()
        {
            // Arrange
            var factory = new KitchenManagerFactory();
            var id = Guid.NewGuid();
            var name = "Manager Name";
            var shift = "Morning";

            // Act
            var kitchenManager = factory.Create(id, name, shift);

            // Assert
            Assert.NotNull(kitchenManager);
            Assert.Equal(id, kitchenManager.Id);
            Assert.Equal(name, kitchenManager.Name);
            Assert.Equal(shift, kitchenManager.Shift);
        }
    }
}
