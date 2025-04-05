using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NutritionalKitchen.Domain.KitchenManager;
using NutritionalKitchen.Infraestructura.DomainModel.config;
using NutritionalKitchen.Infraestructura.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Infraestructura.DomainModel
{
    public class KitchenManagerConfigTest
    {
        [Fact]
        public void KitchenManagerConfig_Should_Apply_Configuration_Correctly()
        {
            // Arrange: Creamos un mock del DbContext y DbSet
            var mockSet = new Mock<DbSet<KitchenManager>>();
            var mockContext = new Mock<DomainDbContext>();

            // Mockeamos el DbSet<KitchenManager> en el DbContext
            mockContext.Setup(m => m.Set<KitchenManager>()).Returns(mockSet.Object);

            // Creamos una instancia de KitchenManagerConfig y aplicamos la configuración
            var config = new KitchenManagerConfig();
            var modelBuilder = new ModelBuilder(new ConventionSet());

            // Act: Configuramos la entidad KitchenManager usando la configuración personalizada
            config.Configure(modelBuilder.Entity<KitchenManager>());

            // Assert: Verificar que las configuraciones se aplicaron correctamente
            var entityType = modelBuilder.Model.FindEntityType(typeof(KitchenManager));

            // Aseguramos que la configuración de la tabla y las columnas están definidas
            Assert.NotNull(entityType);
            Assert.Equal("kitchenManager", entityType.GetTableName());

            var idProperty = entityType.GetProperty("Id");
            Assert.Equal("Id", idProperty.Name);

            var nameProperty = entityType.GetProperty("Name");
            Assert.Equal("Name", nameProperty.Name);

            var shiftProperty = entityType.GetProperty("Shift");
            Assert.Equal("Shift", shiftProperty.Name);
        }
    }
}
