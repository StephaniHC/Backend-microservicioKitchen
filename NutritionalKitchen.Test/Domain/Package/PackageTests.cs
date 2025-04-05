using System;
using Xunit;
using NutritionalKitchen.Domain.Package;

namespace NutritionalKitchen.Test
{
    public class PackageTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties_WhenValidData()
        {
            // Arrange
            var id = Guid.NewGuid();
            var status = "Pending";
            var preparedRecipeId = Guid.NewGuid();
            var batchCode = "BATCH123";

            // Act
            var package = new Package(id, status, preparedRecipeId, batchCode);

            // Assert
            Assert.Equal(id, package.Id);
            Assert.Equal(status, package.Status);
            Assert.Equal(preparedRecipeId, package.PreparedRecipeId);
            Assert.Equal(batchCode, package.BatchCode);
        }

        [Fact]
        public void UpdateStatus_ShouldUpdate_WhenValidStatus()
        {
            // Arrange
            var package = new Package(Guid.NewGuid(), "Pending", Guid.NewGuid(), "BATCH123");
            var newStatus = "Completed";

            // Act
            package.UpdateStatus(newStatus);

            // Assert
            Assert.Equal(newStatus, package.Status);
        }

        [Fact]
        public void UpdateStatus_ShouldThrowException_WhenInvalidStatus()
        {
            // Arrange
            var package = new Package(Guid.NewGuid(), "Pending", Guid.NewGuid(), "BATCH123");

            // Assert
            Assert.Throws<ArgumentException>(() => package.UpdateStatus("InvalidStatus"));
        }
    }
}
