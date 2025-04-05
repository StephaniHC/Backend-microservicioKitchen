using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NutritionalKitchen.Application.KitchenManager.GetKitchenManager;
using NutritionalKitchen.Domain.KitchenManager;
using NutritionalKitchen.Infraestructura.Handlers;
using NutritionalKitchen.Infraestructura.StoredModel;
using NutritionalKitchen.Infraestructura.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using KitchenManagerStoredModel = NutritionalKitchen.Infraestructura.StoredModel.Entities.KitchenManagerStoredModel;

namespace NutritionalKitchen.Test.Infraestructura.Handler
{
    public class GetKitchenManagerHandlerTest
    {
        private readonly Mock<StoredDbContext> _dbContext;

        public GetKitchenManagerHandlerTest()
        {
            var options = new DbContextOptions<StoredDbContext>();
            _dbContext = new Mock<StoredDbContext>(options);
        }

        [Fact]
        public async Task Handle_ShouldReturnKitchenManagers()
        {
            // Arrange
            var kitchenManagers = new List< KitchenManagerStoredModel>
            {
                new KitchenManagerStoredModel { Id = Guid.NewGuid(), Name = "Manager1", Shift = "Morning" },
                new KitchenManagerStoredModel { Id = Guid.NewGuid(), Name = "Manager2", Shift = "Evening" }
            };
             
            _dbContext.Setup(x => x.KitchenManager).ReturnsDbSet(kitchenManagers);

            var handler = new GetKitchenManagerHandler(_dbContext.Object);
            var query = new GetKitchenManagerQuery(" "); 
            var cancellationToken = new CancellationTokenSource(1000).Token;

            // Act
            var result = await handler.Handle(query, cancellationToken);

            // Assert
            Assert.NotNull(result);
            var resultList = result.ToList();
            Assert.Equal(2, resultList.Count);
            Assert.Equal("Manager1", resultList[0].Name);
            Assert.Equal("Manager2", resultList[1].Name);
            Assert.Equal("Morning", resultList[0].Shift);
            Assert.Equal("Evening", resultList[1].Shift);
        }
    }
}
