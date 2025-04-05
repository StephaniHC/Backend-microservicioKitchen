using NutritionalKitchen.Application.Package.GetPackages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Application.Package
{
    public class PackageDto_Test
    {
        [Fact]
        public void PackageDto_CheckPropertiesValid()
        { 
            Guid id = Guid.NewGuid();
            string status = "Prepared";
            Guid preparedRecipeId = Guid.NewGuid();
            string batchCode = "BATCH001";
             
            PackageDto packageDto = new();
             
            Assert.Equal(Guid.Empty, packageDto.Id);
            Assert.Null(packageDto.Status);
            Assert.Equal(Guid.Empty, packageDto.PreparedRecipeId);
            Assert.Null(packageDto.BatchCode); 

            packageDto.Id = id;
            packageDto.Status = status;
            packageDto.PreparedRecipeId = preparedRecipeId;
            packageDto.BatchCode = batchCode;
             
            Assert.Equal(id, packageDto.Id);
            Assert.Equal(status, packageDto.Status);
            Assert.Equal(preparedRecipeId, packageDto.PreparedRecipeId);
            Assert.Equal(batchCode, packageDto.BatchCode);
        }
    }
}
