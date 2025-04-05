using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NutritionalKitchen.Domain.Recipe;
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
    public class RecipeConfigTest
    {
        [Fact]
        public void RecipeConfig_Should_Apply_Configuration_Correctly()
        {
            // Arrange: Creamos un mock del DbContext y DbSet
            var mockSet = new Mock<DbSet<Recipe>>();
            var mockContext = new Mock<DomainDbContext>();

            // Mockeamos el DbSet<Recipe> en el DbContext
            mockContext.Setup(m => m.Set<Recipe>()).Returns(mockSet.Object);

            // Creamos una instancia de RecipeConfig y aplicamos la configuración
            var config = new RecipeConfig();
            var modelBuilder = new ModelBuilder(new ConventionSet());

            // Act: Configuramos la entidad Recipe usando la configuración personalizada
            config.Configure(modelBuilder.Entity<Recipe>());

            // Assert: Verificar que las configuraciones se aplicaron correctamente
            var entityType = modelBuilder.Model.FindEntityType(typeof(Recipe));

            // Aseguramos que la configuración de la tabla y las columnas están definidas
            Assert.NotNull(entityType);
            Assert.Equal("recipe", entityType.GetTableName());

            // Verificamos la propiedad Id
            var idProperty = entityType.GetProperty("Id");
            Assert.Equal("Id", idProperty.Name);
            Assert.True(idProperty.IsPrimaryKey());

            // Verificamos la propiedad Name
            var nameProperty = entityType.GetProperty("Name");
            Assert.Equal("Name", nameProperty.Name);

            // Verificamos la propiedad PreparationTime
            var preparationTimeProperty = entityType.GetProperty("PreparationTime");
            Assert.Equal("PreparationTime", preparationTimeProperty.Name);
        }
    }
}
