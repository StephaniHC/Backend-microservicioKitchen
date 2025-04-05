using Moq;
using NutritionalKitchen.Application.Label.CreateLabel;
using NutritionalKitchen.Application.Package.CreatePackage;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CreateCommandHandler = NutritionalKitchen.Application.Package.CreatePackage.CreateCommandHandler;

namespace NutritionalKitchen.Test.Application.Package
{
    public class CreateCommandHandlerTest
    {
        private IPackageFactory object1;
        private IPackageRepository object2;
        private IUnitOfWork object3;

        [Fact]
        public async Task Handle_ShouldCreatePackage_AndReturnPackageId_WhenValidRequest()
        {
            // Arrange
            var packageId = Guid.NewGuid();
            var batchCode = "746332";
            var status = "Active";
            var preparedRecipeId = Guid.NewGuid();
            var command = new CreateIPackageCommand(packageId, status, batchCode, preparedRecipeId);

            // Mock de las dependencias
            var mockPackageFactory = new Mock<IPackageFactory>();
            var mockPackageRepository = new Mock<IPackageRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var createdPackage = new NutritionalKitchen.Domain.Package.Package(packageId, status, preparedRecipeId, batchCode);

            // Configurar el mock para que devuelva el paquete creado
            mockPackageFactory
                .Setup(factory => factory.Create(packageId, status, batchCode, preparedRecipeId))
                .Returns(createdPackage);

            // Configurar la ejecución de la función que no realiza nada en el repositorio y el UoW
            mockPackageRepository
                .Setup(repo => repo.AddAsync(It.IsAny<NutritionalKitchen.Domain.Package.Package>()))
                .Returns(Task.CompletedTask);

            mockUnitOfWork
                .Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Act
            var handler = new CreateCommandHandler(
                mockPackageFactory.Object,
                mockPackageRepository.Object,
                mockUnitOfWork.Object
            );

            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(packageId, result);

            mockPackageFactory.Verify(factory => factory.Create(packageId, status, batchCode, preparedRecipeId), Times.Once);
            mockPackageRepository.Verify(repo => repo.AddAsync(It.IsAny<NutritionalKitchen.Domain.Package.Package>()), Times.Once);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(CancellationToken.None), Times.Once);
        }
  

        [Fact]
        public async Task Handle_ShouldThrowException_WhenFactoryThrowsException()
        {
            // Arrange
            var packageId = Guid.NewGuid();
            var batchCode = "746332";
            var status = "Active";
            var preparedRecipeId = Guid.NewGuid();
            var command = new CreateIPackageCommand(packageId, status, batchCode, preparedRecipeId);

            var mockPackageFactory = new Mock<IPackageFactory>();
            var mockPackageRepository = new Mock<IPackageRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockPackageFactory
                .Setup(factory => factory.Create(packageId, status, batchCode, preparedRecipeId))
                .Throws(new ArgumentException("Invalid data"));

            var handler = new CreateCommandHandler(
                mockPackageFactory.Object,
                mockPackageRepository.Object,
                mockUnitOfWork.Object
            );

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(command, CancellationToken.None));

            mockPackageFactory.Verify(factory => factory.Create(packageId, status, batchCode, preparedRecipeId), Times.Once);
            mockPackageRepository.Verify(repo => repo.AddAsync(It.IsAny<NutritionalKitchen.Domain.Package.Package>()), Times.Never);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenRepositoryThrowsException()
        {
            // Arrange
            var packageId = Guid.NewGuid();
            var batchCode = "746332";
            var status = "Active";
            var preparedRecipeId = Guid.NewGuid();
            var command = new CreateIPackageCommand(packageId, status, batchCode, preparedRecipeId);

            var mockPackageFactory = new Mock<IPackageFactory>();
            var mockPackageRepository = new Mock<IPackageRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var createdPackage = new NutritionalKitchen.Domain.Package.Package(packageId, status, preparedRecipeId, batchCode);

            mockPackageFactory
                .Setup(factory => factory.Create(packageId, status, batchCode, preparedRecipeId))
                .Returns(createdPackage);

            mockPackageRepository
                .Setup(repo => repo.AddAsync(createdPackage))
                .Throws(new Exception("Database error"));

            var handler = new CreateCommandHandler(
                mockPackageFactory.Object,
                mockPackageRepository.Object,
                mockUnitOfWork.Object
            );

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => handler.Handle(command, CancellationToken.None));

            mockPackageFactory.Verify(factory => factory.Create(packageId, status, batchCode, preparedRecipeId), Times.Once);
            mockPackageRepository.Verify(repo => repo.AddAsync(createdPackage), Times.Once);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
} 
