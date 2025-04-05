using NutritionalKitchen.Application.Label.GetLabel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Application.Label
{
    public class LabelDto_Test
    {
        [Fact]
        public void LabelDto_CheckPropertiesValid()
        { 
            Guid batchCode = Guid.NewGuid();
            DateTime productionDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now.AddMonths(6);
            string detail = "Product detail";
            string address = "123 Main St, City, Country";
            Guid patientId = Guid.NewGuid();
             
            LabelDto labelDto = new();
             
            Assert.Equal(Guid.Empty, labelDto.BatchCode);
            Assert.Equal(default(DateTime), labelDto.ProductionDate);
            Assert.Equal(default(DateTime), labelDto.ExpirationDate);
            Assert.Null(labelDto.Detail);
            Assert.Null(labelDto.Address);
            Assert.Equal(Guid.Empty, labelDto.PatientId);
             
            labelDto.BatchCode = batchCode;
            labelDto.ProductionDate = productionDate;
            labelDto.ExpirationDate = expirationDate;
            labelDto.Detail = detail;
            labelDto.Address = address;
            labelDto.PatientId = patientId;
              
            Assert.Equal(batchCode, labelDto.BatchCode);
            Assert.Equal(productionDate, labelDto.ProductionDate);
            Assert.Equal(expirationDate, labelDto.ExpirationDate);
            Assert.Equal(detail, labelDto.Detail);
            Assert.Equal(address, labelDto.Address);
            Assert.Equal(patientId, labelDto.PatientId);
        }
    }
}
