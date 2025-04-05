using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using NutritionalKitchen.Application.Label.CreateLabel;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.Package;
using Xunit;

namespace NutritionalKitchen.Test.Application.Label
{
    public class CreateCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldCreateLabel_AndReturnBatchCode_WhenValidRequest()
        {
            // Arrange
            var batchCode = Guid.NewGuid();
            var productionDate = DateTime.Now.AddDays(-1);
            var expirationDate = DateTime.Now.AddDays(30);
            var detail = "Test Detail";
            var address = "Test Address";
            var patientId = Guid.NewGuid();
            var command = new CreateLabelCommand(batchCode, productionDate, expirationDate, detail, address, patientId);

            var mockLabelFactory = new Mock<ILabelFactory>();
            var mockLabelRepository = new Mock<ILabelRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var createdLabel = new NutritionalKitchen.Domain.Package.Label(batchCode, productionDate, expirationDate, detail, address, patientId);

            mockLabelFactory
                .Setup(factory => factory.Create(batchCode, productionDate, expirationDate, detail, address, patientId))
                .Returns(createdLabel);

            var handler = new CreateCommandHandler(
                mockLabelFactory.Object,
                mockLabelRepository.Object,
                mockUnitOfWork.Object
            );

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(batchCode, result);

            mockLabelFactory.Verify(factory => factory.Create(batchCode, productionDate, expirationDate, detail, address, patientId), Times.Once);
            mockLabelRepository.Verify(repo => repo.AddAsync(createdLabel), Times.Once);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenFactoryThrowsException()
        {
            // Arrange
            var batchCode = Guid.NewGuid();
            var productionDate = DateTime.Now.AddDays(-1);
            var expirationDate = DateTime.Now.AddDays(30);
            var detail = "Test Detail";
            var address = "Test Address";
            var patientId = Guid.NewGuid();
            var command = new CreateLabelCommand(batchCode, productionDate, expirationDate, detail, address, patientId);

            var mockLabelFactory = new Mock<ILabelFactory>();
            var mockLabelRepository = new Mock<ILabelRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockLabelFactory
                .Setup(factory => factory.Create(batchCode, productionDate, expirationDate, detail, address, patientId))
                .Throws(new ArgumentException("Invalid data"));

            var handler = new CreateCommandHandler(
                mockLabelFactory.Object,
                mockLabelRepository.Object,
                mockUnitOfWork.Object
            );

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(command, CancellationToken.None));

            mockLabelFactory.Verify(factory => factory.Create(batchCode, productionDate, expirationDate, detail, address, patientId), Times.Once);
            mockLabelRepository.Verify(repo => repo.AddAsync(It.IsAny<NutritionalKitchen.Domain.Package.Label>()), Times.Never);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenRepositoryThrowsException()
        {
            // Arrange
            var batchCode = Guid.NewGuid();
            var productionDate = DateTime.Now.AddDays(-1);
            var expirationDate = DateTime.Now.AddDays(30);
            var detail = "Test Detail";
            var address = "Test Address";
            var patientId = Guid.NewGuid();
            var command = new CreateLabelCommand(batchCode, productionDate, expirationDate, detail, address, patientId);

            var mockLabelFactory = new Mock<ILabelFactory>();
            var mockLabelRepository = new Mock<ILabelRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var createdLabel = new NutritionalKitchen.Domain.Package.Label(batchCode, productionDate, expirationDate, detail, address, patientId);

            mockLabelFactory
                .Setup(factory => factory.Create(batchCode, productionDate, expirationDate, detail, address, patientId))
                .Returns(createdLabel);

            mockLabelRepository
                .Setup(repo => repo.AddAsync(createdLabel))
                .Throws(new Exception("Database error"));

            var handler = new CreateCommandHandler(
                mockLabelFactory.Object,
                mockLabelRepository.Object,
                mockUnitOfWork.Object
            );

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => handler.Handle(command, CancellationToken.None));

            mockLabelFactory.Verify(factory => factory.Create(batchCode, productionDate, expirationDate, detail, address, patientId), Times.Once);
            mockLabelRepository.Verify(repo => repo.AddAsync(createdLabel), Times.Once);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
