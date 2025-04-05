using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Moq;
using NutritionalKitchen.Domain.Ingredients;
using NutritionalKitchen.Infraestructura.DomainModel;
using NutritionalKitchen.Infraestructura.DomainModel.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Infraestructura.DomainModel
{
    public class IngredientsConfigTest
    {
        [Fact]
        public void IngredientsConfig_Should_Apply_Configuration_Correctly()
        {
            // Arrange: Creamos un mock de DbContext y DbSet
            var mockSet = new Mock<DbSet<Ingredients>>();
            var mockContext = new Mock<DomainDbContext>();

            // Mockear el DbSet<Ingredients> en el DbContext
            mockContext.Setup(m => m.Set<Ingredients>()).Returns(mockSet.Object);

            // Creamos una instancia de IngredientsConfig y aplicamos la configuración
            var config = new IngredientsConfig();
            var modelBuilder = new ModelBuilder(new ConventionSet());

            // Act: Configuramos la entidad Ingredients usando la configuración personalizada
            config.Configure(modelBuilder.Entity<Ingredients>());

            // Assert: Verificar que las configuraciones se aplicaron correctamente
            var entityType = modelBuilder.Model.FindEntityType(typeof(Ingredients));

            // Aseguramos que la configuración de la tabla y las columnas están definidas
            Assert.NotNull(entityType);
            Assert.Equal("ingredients", entityType.GetTableName());

            var idProperty = entityType.GetProperty("Id");
            Assert.Equal("Id", idProperty.Name);

            var nameProperty = entityType.GetProperty("Name");
            Assert.Equal("Name", nameProperty.Name);
        }
    }
}
