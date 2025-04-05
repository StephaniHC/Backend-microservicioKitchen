using NutritionalKitchen.Domain.KitchenManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Domain.KitchenManager
{
    public class KitchenManagerTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties_WhenValidData()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Stephani";
            var shift = "Morning";

            // Act
            var manager = new NutritionalKitchen.Domain.KitchenManager.KitchenManager(id, name, shift);

            // Assert
            Assert.Equal(id, manager.Id);
            Assert.Equal(name, manager.Name); 
        } 

        [Fact]
        public void UpdateName_ShouldUpdateName_WhenValidName()
        {
            // Arrange
            var manager = new NutritionalKitchen.Domain.KitchenManager.KitchenManager(Guid.NewGuid(), "Stephani", "Morning");
            var newName = "Heredia";

            // Act
            manager.UpdateName(newName);

            // Assert
            Assert.Equal(newName, manager.Name);
        }

        [Fact]
        public void UpdateName_ShouldThrowException_WhenNameIsEmpty()
        {
            // Arrange
            var manager = new NutritionalKitchen.Domain.KitchenManager.KitchenManager(Guid.NewGuid(), "Stephani", "Morning");

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => manager.UpdateName(""));
            Assert.Equal("El nombre no puede estar vacío.", exception.Message);
        }

        [Fact]
        public void UpdateShift_ShouldUpdateShift_WhenValidShift()
        {
            // Arrange
            var manager = new NutritionalKitchen.Domain.KitchenManager.KitchenManager(Guid.NewGuid(), "Stephani", "Morning");
            var newShift = "Afternoon";

            // Act
            manager.UpdateShift(newShift);

            // Assert
            Assert.Equal(newShift, manager.Shift);
        }

        [Fact]
        public void UpdateShift_ShouldThrowException_WhenShiftIsInvalid()
        {
            // Arrange
            var manager = new NutritionalKitchen.Domain.KitchenManager.KitchenManager(Guid.NewGuid(), "Stephani", "Morning");

            // Assert
            var exception = Assert.Throws<ArgumentException>(() => manager.UpdateShift("Invalido"));
            Assert.Equal("El turno especificado no es válido.", exception.Message);
        }
    }
}
