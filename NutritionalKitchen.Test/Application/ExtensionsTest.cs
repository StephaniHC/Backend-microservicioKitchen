using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NutritionalKitchen.Application;
using NutritionalKitchen.Domain.Ingredients;
using NutritionalKitchen.Domain.KitchenManager;
using NutritionalKitchen.Domain.Package;
using NutritionalKitchen.Domain.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Application
{
    public class ExtensionsTest
    {
        [Fact]
        public void AddApplication_ShouldRegisterServicesCorrectly()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            services.AddAplication();

            // Assert
            var serviceProvider = services.BuildServiceProvider();

            // Verificar que los servicios están registrados correctamente
            Assert.NotNull(serviceProvider.GetService<IRecipeFactory>());
            Assert.NotNull(serviceProvider.GetService<IIngredientFactory>());
            Assert.NotNull(serviceProvider.GetService<IKitchenManagerFactory>());
            Assert.NotNull(serviceProvider.GetService<IPackageFactory>());
            Assert.NotNull(serviceProvider.GetService<ILabelFactory>());

            // Verificar que MediatR está registrado
            var mediator = serviceProvider.GetService<IMediator>();
            Assert.NotNull(mediator);
        }
    }
}
