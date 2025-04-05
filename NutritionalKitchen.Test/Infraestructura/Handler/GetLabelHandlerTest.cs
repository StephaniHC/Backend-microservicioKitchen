using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NutritionalKitchen.Application.Label.GetLabel;
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
    public class GetLabelHandlerTest
    {
        private readonly Mock<StoredDbContext> _dbContext;

        public GetLabelHandlerTest()
        {
            var options = new DbContextOptions<StoredDbContext>();
            _dbContext = new Mock<StoredDbContext>(options);
        }

        [Fact]
        public async Task Handle_ShouldReturnLabels()
        {
            // Arrange
            var labels = new List<LabelStoredModel>
            {
                new LabelStoredModel { BatchCode = Guid.NewGuid(), ProductionDate = DateTime.Now, ExpirationDate = DateTime.Now.AddMonths(6), Detail = "Label 1", Address = "Address 1", PatientId = Guid.NewGuid() },
                new LabelStoredModel { BatchCode = Guid.NewGuid(), ProductionDate = DateTime.Now, ExpirationDate = DateTime.Now.AddMonths(6), Detail = "Label 2", Address = "Address 2", PatientId = Guid.NewGuid() }
            };
             
            _dbContext.Setup(x => x.Label).ReturnsDbSet(labels);

            var handler = new GetLabelHandler(_dbContext.Object);
            var query = new GetLabelQuery(" ");  
            var cancellationToken = new CancellationTokenSource(1000).Token;

            // Act
            var result = await handler.Handle(query, cancellationToken);

            // Assert
            Assert.NotNull(result);
            var resultList = result.ToList();
            Assert.Equal(2, resultList.Count);  
        }
    }
}
