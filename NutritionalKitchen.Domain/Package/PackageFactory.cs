using NutritionalKitchen.Domain.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Package
{
    public class PackageFactory : IPackageFactory
    {
        public Package Create(Guid id, string status, string batchCode, Guid preparedRecipeId)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id is required", nameof(id));
            }

            if (string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentException("Status is required", nameof(status));
            }

            if (string.IsNullOrWhiteSpace(batchCode))
            {
                throw new ArgumentException("Batch code is required", nameof(batchCode));
            }

            if (preparedRecipeId == Guid.Empty)
            {
                throw new ArgumentException("preparedRecipeId is required", nameof(preparedRecipeId));
            }

            return new Package(id, status, preparedRecipeId, batchCode);
        }
    }

}
