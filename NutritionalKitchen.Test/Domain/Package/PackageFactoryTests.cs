using System;
using Xunit;
using NutritionalKitchen.Domain.Package;

namespace NutritionalKitchen.Test
{
    public class PackageFactoryTests
    {
        private readonly PackageFactory _factory;

        public PackageFactoryTests()
        {
            _factory = new PackageFactory();
        }

        [Fact]
        public void Create_ShouldReturnPackage_WhenValidParameters()
        {
            // Arrange
            var id = Guid.NewGuid();
            var status = "Active";
            var batchCode = "BATCH123";
            var preparedRecipeId = Guid.NewGuid();

            // Act
            var package = _factory.Create(id, status, batchCode, preparedRecipeId);

            // Assert
            Assert.NotNull(package);
            Assert.Equal(id, package.Id);
            Assert.Equal(status, package.Status);
            Assert.Equal(batchCode, package.BatchCode);
            Assert.Equal(preparedRecipeId, package.PreparedRecipeId);
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000", "Active", "BATCH123", "d3b07384-d9f4-4c28-aec5-10f3c3d23a3d", "Id is required")]
        [InlineData("d3b07384-d9f4-4c28-aec5-10f3c3d23a3d", "", "BATCH123", "d3b07384-d9f4-4c28-aec5-10f3c3d23a3d", "Status is required")]
        [InlineData("d3b07384-d9f4-4c28-aec5-10f3c3d23a3d", "Active", "", "d3b07384-d9f4-4c28-aec5-10f3c3d23a3d", "Batch code is required")]
        [InlineData("d3b07384-d9f4-4c28-aec5-10f3c3d23a3d", "Active", "BATCH123", "00000000-0000-0000-0000-000000000000", "preparedRecipeId is required")]
        public void Create_ShouldThrowException_WhenInvalidParameters(
            string idStr, string status, string batchCode, string preparedRecipeIdStr, string expectedMessage)
        {
            // Convertir GUIDs válidos correctamente
            var id = Guid.Parse(idStr);
            var preparedRecipeId = Guid.Parse(preparedRecipeIdStr);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                _factory.Create(id, status, batchCode, preparedRecipeId));

            Assert.Contains(expectedMessage, exception.Message);
        }


    }
}
