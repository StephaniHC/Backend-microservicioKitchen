using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Domain.Abstraction
{
    public class EntityTest
    {
        private class ConcreteEntity : Entity
        {
            public ConcreteEntity(Guid id) : base(id)
            {
            }
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenIdIsEmpty()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new ConcreteEntity(Guid.Empty));
            Assert.Equal("Id cannot be empty (Parameter 'id')", exception.Message);
        }

        [Fact]
        public void Constructor_ShouldSetId_WhenIdIsValid()
        {
            // Arrange
            var validId = Guid.NewGuid();

            // Act
            var entity = new ConcreteEntity(validId);

            // Assert
            Assert.Equal(validId, entity.Id);
        }
    }
}
