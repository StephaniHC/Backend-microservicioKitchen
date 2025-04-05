using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Package
{ 
    public interface ILabelRepository : IRepository<Label>
    {
        Task AddAsync(Label entity);
        Task UpdateAsync(Label label);
        Task DeleteAsync(Guid id);
    }
}
