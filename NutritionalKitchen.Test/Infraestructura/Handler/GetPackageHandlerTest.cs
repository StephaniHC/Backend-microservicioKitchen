using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NutritionalKitchen.Application.Package.GetPackages;
using NutritionalKitchen.Domain.Package;
using NutritionalKitchen.Infraestructura.Handlers;
using NutritionalKitchen.Infraestructura.StoredModel;
using NutritionalKitchen.Infraestructura.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Infraestructura.Handler
{
    public class GetPackageHandlerTest
    {
        private readonly Mock<StoredDbContext> _dbContext;

        public GetPackageHandlerTest()
        {
            var options = new DbContextOptions<StoredDbContext>();
            _dbContext = new Mock<StoredDbContext>(options);
        }

        [Fact]
        public async Task Handle_ShouldReturnPackages()
        {
            // Arrange
            var packages = new List<PackageStoredModel>
            {
                new PackageStoredModel { Id = Guid.NewGuid(), Status = "Active", PreparedRecipeId = Guid.NewGuid(), BatchCode = "A123" },
                new PackageStoredModel { Id = Guid.NewGuid(), Status = "Inactive", PreparedRecipeId = Guid.NewGuid(), BatchCode = "B456" }
            };
             
            _dbContext.Setup(x => x.Package).ReturnsDbSet(packages);

            var handler = new GetPackageHandler(_dbContext.Object);
            var query = new GetPackageQuery("");  
            var cancellationToken = new CancellationTokenSource(1000).Token;

            // Act
            var result = await handler.Handle(query, cancellationToken);

            // Assert
            Assert.NotNull(result);
            var resultList = result.ToList();
            Assert.Equal(2, resultList.Count);
            Assert.Equal("A123", resultList[0].BatchCode);
            Assert.Equal("B456", resultList[1].BatchCode);
            Assert.Equal("Active", resultList[0].Status);
            Assert.Equal("Inactive", resultList[1].Status);
        }
    }
}
