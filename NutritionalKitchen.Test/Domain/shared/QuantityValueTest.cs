using NutritionalKitchen.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Domain.shared
{
    public class QuantityValueTest
    {
        [Fact]
        public void ImplicitConversion_ToDouble_ShouldReturnValue_WhenNotNull()
        {
            // Arrange
            var quantity = new QuantityValue(10.5);

            // Act
            double result = quantity;

            // Assert
            Assert.Equal(10.5, result);
        }

        [Fact]
        public void ImplicitConversion_ToDouble_ShouldReturnZero_WhenNull()
        {
            // Arrange
            QuantityValue quantity = null;

            // Act
            double result = quantity;

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void ImplicitConversion_ToQuantityValue_ShouldReturnQuantity_WhenValidValue()
        {
            // Arrange
            double value = 15.75;

            // Act
            QuantityValue quantity = value;

            // Assert
            Assert.Equal(value, quantity.Value);
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenValueIsNegative()
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new QuantityValue(-5));
            Assert.Equal("La cantidad debe ser mayor a cero. (Parameter 'value')", exception.Message);
        }
    }
}
