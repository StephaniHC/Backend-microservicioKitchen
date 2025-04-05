using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NutritionalKitchen.Domain.Package;
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
    public class PackageConfigTest
    {
        [Fact]
        public void PackageConfig_Should_Apply_Configuration_Correctly()
        {
            // Arrange: Creamos un mock del DbContext y DbSet
            var mockSet = new Mock<DbSet<Package>>();
            var mockContext = new Mock<DomainDbContext>();

            // Mockeamos el DbSet<Package> en el DbContext
            mockContext.Setup(m => m.Set<Package>()).Returns(mockSet.Object);

            // Creamos una instancia de PackageConfig y aplicamos la configuración
            var config = new PackageConfig();
            var modelBuilder = new ModelBuilder(new ConventionSet());

            // Act: Configuramos la entidad Package usando la configuración personalizada
            config.Configure(modelBuilder.Entity<Package>());

            // Assert: Verificar que las configuraciones se aplicaron correctamente
            var entityType = modelBuilder.Model.FindEntityType(typeof(Package));

            // Aseguramos que la configuración de la tabla y las columnas están definidas
            Assert.NotNull(entityType);
            Assert.Equal("package", entityType.GetTableName());

            // Verificamos la propiedad Id
            var idProperty = entityType.GetProperty("Id");
            Assert.Equal("Id", idProperty.Name);
            Assert.True(idProperty.IsPrimaryKey());

            // Verificamos las otras propiedades
            var statusProperty = entityType.GetProperty("Status");
            Assert.Equal("Status", statusProperty.Name);

            var preparedRecipeIdProperty = entityType.GetProperty("PreparedRecipeId");
            Assert.Equal("PreparedRecipeId", preparedRecipeIdProperty.Name);

            var batchCodeProperty = entityType.GetProperty("BatchCode");
            Assert.Equal("BatchCode", batchCodeProperty.Name);
        }
    }
}
