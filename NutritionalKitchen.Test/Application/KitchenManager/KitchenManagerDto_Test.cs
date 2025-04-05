using NutritionalKitchen.Application.KitchenManager.GetKitchenManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Application.KitchenManager
{
    public class KitchenManagerDto_Test
    {
        [Fact]
        public void KitchenManagerDto_CheckPropertiesValid()
        { 
            Guid id = Guid.NewGuid();
            string name = "Chef John";
            string shift = "Morning";
             
            KitchenManagerDto kitchenManagerDto = new();
             
            Assert.Equal(Guid.Empty, kitchenManagerDto.Id);
            Assert.Null(kitchenManagerDto.Name);
            Assert.Null(kitchenManagerDto.Shift);
             
            kitchenManagerDto.Id = id;
            kitchenManagerDto.Name = name;
            kitchenManagerDto.Shift = shift;
             
            Assert.Equal(id, kitchenManagerDto.Id);
            Assert.Equal(name, kitchenManagerDto.Name);
            Assert.Equal(shift, kitchenManagerDto.Shift);
        }
    }
}
