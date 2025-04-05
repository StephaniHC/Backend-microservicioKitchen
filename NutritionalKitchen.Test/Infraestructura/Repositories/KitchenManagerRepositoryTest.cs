using Microsoft.EntityFrameworkCore;
using Moq;
using NutritionalKitchen.Domain.KitchenManager;
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
    public class KitchenManagerRepositoryTest
    {
        private readonly Mock<DomainDbContext> _dbContext;
        private readonly KitchenManagerRepository _repository;
        private readonly Mock<DbSet<KitchenManager>> _kitchenManagerDbSet;

        public KitchenManagerRepositoryTest()
        {
            var options = new DbContextOptions<DomainDbContext>();
            _dbContext = new Mock<DomainDbContext>(options);
             
            _kitchenManagerDbSet = new Mock<DbSet<KitchenManager>>();

            _dbContext.Setup(x => x.KitchenManager).Returns(_kitchenManagerDbSet.Object);

            _repository = new KitchenManagerRepository(_dbContext.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldAddKitchenManager()
        {
            // Arrange
            var kitchenManager = new KitchenManager ( Guid.NewGuid(), "Test Manager", "Test Manager");

            // Act
            await _repository.AddAsync(kitchenManager);

            // Assert
            _kitchenManagerDbSet.Verify(x => x.AddAsync(kitchenManager, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
