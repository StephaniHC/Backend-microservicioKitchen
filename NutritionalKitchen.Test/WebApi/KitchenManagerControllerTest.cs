using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NutritionalKitchen.Application.KitchenManager.CreateKitchenManager;
using NutritionalKitchen.Application.KitchenManager.GetKitchenManager;
using NutritionalKitchen.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.WebApi
{
    public class KitchenManagerControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly KitchenManagerController _controller;

        public KitchenManagerControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new KitchenManagerController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateKitchenManager_ShouldReturnOk_WhenSuccessful()
        {
            // Arrange
            var command = new CreateKitchenManagerCommand(Guid.NewGuid(), "John Doe", "Morning");
            var expectedId = Guid.NewGuid();

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateKitchenManagerCommand>(), default))
                .ReturnsAsync(expectedId);

            // Act
            var result = await _controller.CreateKitchenManager(command);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedId, actionResult.Value);
        }

        [Fact]
        public async Task CreateKitchenManager_ShouldReturnInternalServerError_WhenExceptionOccurs()
        {
            // Arrange
            var command = new CreateKitchenManagerCommand(Guid.NewGuid(), "John Doe", "Morning");

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateKitchenManagerCommand>(), default))
                .ThrowsAsync(new Exception("Database Error"));

            // Act
            var result = await _controller.CreateKitchenManager(command);

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, actionResult.StatusCode);
            Assert.Equal("Database Error", actionResult.Value);
        }

        [Fact]
        public async Task GetKitchenManager_ShouldReturnOk_WhenSuccessful()
        {
            // Arrange
            var managers = new List<KitchenManagerDto>
            {
                new KitchenManagerDto { Id = Guid.NewGuid(), Name = "Alice", Shift = "Morning" },
                new KitchenManagerDto { Id = Guid.NewGuid(), Name = "Bob", Shift = "Night" }
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetKitchenManagerQuery>(), default))
                .ReturnsAsync(managers);

            // Act
            var result = await _controller.GetKitchenManager();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnedManagers = Assert.IsAssignableFrom<IEnumerable<KitchenManagerDto>>(actionResult.Value);
            Assert.Equal(managers.Count, returnedManagers.Count());
        }

        [Fact]
        public async Task GetKitchenManager_ShouldReturnInternalServerError_WhenExceptionOccurs()
        {
            // Arrange
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetKitchenManagerQuery>(), default))
                .ThrowsAsync(new Exception("Service Unavailable"));

            // Act
            var result = await _controller.GetKitchenManager();

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, actionResult.StatusCode);
            Assert.Equal("Service Unavailable", actionResult.Value);
        }
    } 
}
