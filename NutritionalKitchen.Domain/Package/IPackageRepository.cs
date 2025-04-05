using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Package
{
    public interface IPackageRepository : IRepository<Package>
    {
        Task AddAsync(Package entity);
        Task UpdateAsync(Package package);
        Task DeleteAsync(Guid id);
    }
}
