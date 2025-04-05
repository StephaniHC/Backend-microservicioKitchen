using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NutritionalKitchen.Application.Label.CreateLabel;
using NutritionalKitchen.Application.Label.GetLabel;
using NutritionalKitchen.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.WebApi
{
    public class LabelControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly LabelController _controller;

        public LabelControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new LabelController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateLabel_ShouldReturnOk_WhenSuccessful()
        {
            // Arrange
            var command = new CreateLabelCommand(
                Guid.NewGuid(),
                DateTime.UtcNow,
                DateTime.UtcNow.AddDays(30),
                "Detail example",
                "123 Street",
                Guid.NewGuid()
            );

            var expectedId = Guid.NewGuid();

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateLabelCommand>(), default))
                .ReturnsAsync(expectedId);

            // Act
            var result = await _controller.CreateLabel(command);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedId, actionResult.Value);
        }

        [Fact]
        public async Task CreateLabel_ShouldReturnInternalServerError_WhenExceptionOccurs()
        {
            // Arrange
            var command = new CreateLabelCommand(
                Guid.NewGuid(),
                DateTime.UtcNow,
                DateTime.UtcNow.AddDays(30),
                "Detail example",
                "123 Street",
                Guid.NewGuid()
            );

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateLabelCommand>(), default))
                .ThrowsAsync(new Exception("Database Error"));

            // Act
            var result = await _controller.CreateLabel(command);

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, actionResult.StatusCode);
            Assert.Equal("Database Error", actionResult.Value);
        }

        [Fact]
        public async Task GetLabel_ShouldReturnOk_WhenSuccessful()
        {
            // Arrange
            var labels = new List<LabelDto>
            {
                new LabelDto { BatchCode = Guid.NewGuid(), ProductionDate = DateTime.UtcNow, ExpirationDate = DateTime.UtcNow.AddDays(30), Detail = "Milk", Address = "Warehouse A", PatientId = Guid.NewGuid() },
                new LabelDto { BatchCode = Guid.NewGuid(), ProductionDate = DateTime.UtcNow, ExpirationDate = DateTime.UtcNow.AddDays(30), Detail = "Bread", Address = "Warehouse B", PatientId = Guid.NewGuid() }
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetLabelQuery>(), default))
                .ReturnsAsync(labels);

            // Act
            var result = await _controller.GetLabel();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnedLabels = Assert.IsAssignableFrom<IEnumerable<LabelDto>>(actionResult.Value);
            Assert.Equal(labels.Count, returnedLabels.Count());
        }

        [Fact]
        public async Task GetLabel_ShouldReturnInternalServerError_WhenExceptionOccurs()
        {
            // Arrange
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetLabelQuery>(), default))
                .ThrowsAsync(new Exception("Service Unavailable"));

            // Act
            var result = await _controller.GetLabel();

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, actionResult.StatusCode);
            Assert.Equal("Service Unavailable", actionResult.Value);
        }
    }
} 