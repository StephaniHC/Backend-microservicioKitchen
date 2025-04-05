using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Ingredients
{
    public interface IIngredientsRepository : IRepository<Ingredients>
    {
        Task UpdateAsync(Ingredients ingedients);
        Task DeleteAsync(Guid id);
    }
}
