using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Recipe
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task AddAsync(Recipe entity); 
        Task DeleteAsync(Guid id);
       Task UpdateAsync(Recipe recipe); 
    }
}
