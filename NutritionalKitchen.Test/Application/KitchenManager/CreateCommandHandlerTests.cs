using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using NutritionalKitchen.Application.KitchenManager.CreateKitchenManager;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.KitchenManager;
using Xunit;

namespace NutritionalKitchen.Test.Application.KitchenManager
{
    public class CreateCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldCreateKitchenManager_AndReturnId_WhenValidRequest()
        {
            // Arrange
            var kitchenManagerId = Guid.NewGuid();
            var kitchenManagerName = "Stephani";
            var kitchenManagerShift = "Morning";
            var command = new CreateKitchenManagerCommand(kitchenManagerId, kitchenManagerName, kitchenManagerShift);

            var mockKitchenManagerFactory = new Mock<IKitchenManagerFactory>();
            var mockKitchenManagerRepository = new Mock<IKitchenManagerRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var createdKitchenManager = new NutritionalKitchen.Domain.KitchenManager.KitchenManager(kitchenManagerId, kitchenManagerName, kitchenManagerShift);

            mockKitchenManagerFactory
                .Setup(factory => factory.Create(kitchenManagerId, kitchenManagerName, kitchenManagerShift))
                .Returns(createdKitchenManager);

            var handler = new CreateCommandHandler(
                mockKitchenManagerFactory.Object,
                mockKitchenManagerRepository.Object,
                mockUnitOfWork.Object
            );

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(kitchenManagerId, result);

            mockKitchenManagerFactory.Verify(factory => factory.Create(kitchenManagerId, kitchenManagerName, kitchenManagerShift), Times.Once);
            mockKitchenManagerRepository.Verify(repo => repo.AddAsync(createdKitchenManager), Times.Once);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenFactoryThrowsException()
        {
            // Arrange
            var kitchenManagerId = Guid.NewGuid();
            var kitchenManagerName = "Stephani";
            var kitchenManagerShift = "Morning";
            var command = new CreateKitchenManagerCommand(kitchenManagerId, kitchenManagerName, kitchenManagerShift);

            var mockKitchenManagerFactory = new Mock<IKitchenManagerFactory>();
            var mockKitchenManagerRepository = new Mock<IKitchenManagerRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockKitchenManagerFactory
                .Setup(factory => factory.Create(kitchenManagerId, kitchenManagerName, kitchenManagerShift))
                .Throws(new ArgumentException("Invalid data"));

            var handler = new CreateCommandHandler(
                mockKitchenManagerFactory.Object,
                mockKitchenManagerRepository.Object,
                mockUnitOfWork.Object
            );

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(command, CancellationToken.None));

            mockKitchenManagerFactory.Verify(factory => factory.Create(kitchenManagerId, kitchenManagerName, kitchenManagerShift), Times.Once);
            mockKitchenManagerRepository.Verify(repo => repo.AddAsync(It.IsAny<NutritionalKitchen.Domain.KitchenManager.KitchenManager>()), Times.Never);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenRepositoryThrowsException()
        {
            // Arrange
            var kitchenManagerId = Guid.NewGuid();
            var kitchenManagerName = "Stephani";
            var kitchenManagerShift = "Morning";
            var command = new CreateKitchenManagerCommand(kitchenManagerId, kitchenManagerName, kitchenManagerShift);

            var mockKitchenManagerFactory = new Mock<IKitchenManagerFactory>();
            var mockKitchenManagerRepository = new Mock<IKitchenManagerRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var createdKitchenManager = new NutritionalKitchen.Domain.KitchenManager.KitchenManager(kitchenManagerId, kitchenManagerName, kitchenManagerShift);

            mockKitchenManagerFactory
                .Setup(factory => factory.Create(kitchenManagerId, kitchenManagerName, kitchenManagerShift))
                .Returns(createdKitchenManager);

            mockKitchenManagerRepository
                .Setup(repo => repo.AddAsync(createdKitchenManager))
                .Throws(new Exception("Database error"));

            var handler = new CreateCommandHandler(
                mockKitchenManagerFactory.Object,
                mockKitchenManagerRepository.Object,
                mockUnitOfWork.Object
            );

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => handler.Handle(command, CancellationToken.None));

            mockKitchenManagerFactory.Verify(factory => factory.Create(kitchenManagerId, kitchenManagerName, kitchenManagerShift), Times.Once);
            mockKitchenManagerRepository.Verify(repo => repo.AddAsync(createdKitchenManager), Times.Once);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
