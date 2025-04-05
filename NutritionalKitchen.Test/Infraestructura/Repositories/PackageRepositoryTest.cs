using Microsoft.EntityFrameworkCore;
using Moq;
using NutritionalKitchen.Domain.Package;
using NutritionalKitchen.Infraestructura.DomainModel;
using NutritionalKitchen.Infraestructura.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Infraestructura.Repositories
{
    public class PackageRepositoryTest
    {
        private readonly Mock<DomainDbContext> _dbContextMock;
        private readonly Mock<DbSet<Package>> _packageDbSetMock;
        private readonly PackageRepository _repository;

        public PackageRepositoryTest()
        {
            var options = new DbContextOptions<DomainDbContext>();
            _dbContextMock = new Mock<DomainDbContext>(options);
             
            _packageDbSetMock = new Mock<DbSet<Package>>();
            _dbContextMock.Setup(db => db.Set<Package>()).Returns(_packageDbSetMock.Object);

            _repository = new PackageRepository(_dbContextMock.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldAddPackage()
        {
            // Arrange
            var package = new Package(Guid.NewGuid(), "Test Package", Guid.NewGuid(), "Test Package");

            // Act
            await _repository.AddAsync(package);

            // Assert
            _packageDbSetMock.Verify(db => db.AddAsync(package, It.IsAny<CancellationToken>()), Times.Once);
            _dbContextMock.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
