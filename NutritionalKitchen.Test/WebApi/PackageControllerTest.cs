using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NutritionalKitchen.Application.Package.CreatePackage;
using NutritionalKitchen.Application.Package.GetPackages;
using NutritionalKitchen.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.WebApi
{
    public class PackageControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly PackageController _controller;

        public PackageControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new PackageController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreatePackage_ShouldReturnOk_WhenSuccessful()
        {
            // Arrange
            var command = new CreateIPackageCommand(
                Guid.NewGuid(),
                "Active",
                "Batch-123",
                Guid.NewGuid()
            );

            var expectedId = Guid.NewGuid();

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateIPackageCommand>(), default))
                .ReturnsAsync(expectedId);

            // Act
            var result = await _controller.CreatePackage(command);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedId, actionResult.Value);
        }

        [Fact]
        public async Task CreatePackage_ShouldReturnInternalServerError_WhenExceptionOccurs()
        {
            // Arrange
            var command = new CreateIPackageCommand(
                Guid.NewGuid(),
                "Active",
                "Batch-123",
                Guid.NewGuid()
            );

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateIPackageCommand>(), default))
                .ThrowsAsync(new Exception("Database Error"));

            // Act
            var result = await _controller.CreatePackage(command);

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, actionResult.StatusCode);
            Assert.Equal("Database Error", actionResult.Value);
        }

        [Fact]
        public async Task GetPackage_ShouldReturnOk_WhenSuccessful()
        {
            // Arrange
            var packages = new List<PackageDto>
            {
                new PackageDto { Id = Guid.NewGuid(), Status = "Active", BatchCode = "Batch-001", PreparedRecipeId = Guid.NewGuid() },
                new PackageDto { Id = Guid.NewGuid(), Status = "Inactive", BatchCode = "Batch-002", PreparedRecipeId = Guid.NewGuid() }
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetPackageQuery>(), default))
                .ReturnsAsync(packages);

            // Act
            var result = await _controller.GetPackage();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnedPackages = Assert.IsAssignableFrom<IEnumerable<PackageDto>>(actionResult.Value);
            Assert.Equal(packages.Count, returnedPackages.Count());
        }

        [Fact]
        public async Task GetPackage_ShouldReturnInternalServerError_WhenExceptionOccurs()
        {
            // Arrange
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetPackageQuery>(), default))
                .ThrowsAsync(new Exception("Service Unavailable"));

            // Act
            var result = await _controller.GetPackage();

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, actionResult.StatusCode);
            Assert.Equal("Service Unavailable", actionResult.Value);
        }
    }
} 
