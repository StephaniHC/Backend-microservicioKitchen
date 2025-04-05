using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
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
    public class LabelRepositoryTest
    {
        private readonly Mock<DomainDbContext> _dbContext;
        private readonly LabelRepository _repository;
        private readonly Mock<DbSet<Label>> _labelDbSet;

        public LabelRepositoryTest()
        {
            var options = new DbContextOptions<DomainDbContext>();
            _dbContext = new Mock<DomainDbContext>(options);
             
            _labelDbSet = new Mock<DbSet<Label>>();
            _dbContext.Setup(x => x.Set<Label>()).Returns(_labelDbSet.Object);
            _dbContext.Setup(x => x.Label).ReturnsDbSet(new List<Label>());  

            _repository = new LabelRepository(_dbContext.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldAddLabel()
        {
            // Arrange
            var label = new Label(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow, "Test Label", "Test Label", Guid.NewGuid());

            // Act
            await _repository.AddAsync(label);

            // Assert
            _labelDbSet.Verify(x => x.AddAsync(label, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
