using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NutritionalKitchen.Infraestructura.DomainModel.config;
using NutritionalKitchen.Infraestructura.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NutritionalKitchen.Domain.Package;

namespace NutritionalKitchen.Test.Infraestructura.DomainModel
{
    public class LabelConfigTest
    {
        [Fact]
        public void LabelConfig_Should_Apply_Configuration_Correctly()
        {
            // Arrange: Creamos un mock del DbContext y DbSet
            var mockSet = new Mock<DbSet<Label>>();
            var mockContext = new Mock<DomainDbContext>();

            // Mockeamos el DbSet<Label> en el DbContext
            mockContext.Setup(m => m.Set<Label>()).Returns(mockSet.Object);

            // Creamos una instancia de LabelConfig y aplicamos la configuración
            var config = new LabelConfig();
            var modelBuilder = new ModelBuilder(new ConventionSet());

            // Act: Configuramos la entidad Label usando la configuración personalizada
            config.Configure(modelBuilder.Entity<Label>());

            // Assert: Verificar que las configuraciones se aplicaron correctamente
            var entityType = modelBuilder.Model.FindEntityType(typeof(Label));

            // Aseguramos que la configuración de la tabla y las columnas están definidas
            Assert.NotNull(entityType);
            Assert.Equal("label", entityType.GetTableName());

            // Verificamos la propiedad BatchCode
            var batchCodeProperty = entityType.GetProperty("BatchCode");
            Assert.Equal("BatchCode", batchCodeProperty.Name);
            Assert.True(batchCodeProperty.IsPrimaryKey());

            // Verificamos las propiedades restantes
            var productionDateProperty = entityType.GetProperty("ProductionDate");
            Assert.Equal("ProductionDate", productionDateProperty.Name);

            var expirationDateProperty = entityType.GetProperty("ExpirationDate");
            Assert.Equal("ExpirationDate", expirationDateProperty.Name);

            var detailProperty = entityType.GetProperty("Detail");
            Assert.Equal("Detail", detailProperty.Name);

            var addressProperty = entityType.GetProperty("Address");
            Assert.Equal("Address", addressProperty.Name);

            var patientIdProperty = entityType.GetProperty("PatientId");
            Assert.Equal("PatientId", patientIdProperty.Name);
        }
    }
}
