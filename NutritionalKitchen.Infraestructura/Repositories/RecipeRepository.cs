using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.Package;
using NutritionalKitchen.Domain.Recipe;
using NutritionalKitchen.Infraestructura.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly DomainDbContext _dbContext;

        public RecipeRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Recipe entity)
        {
            await _dbContext.Set<Recipe>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<Recipe?> IRepository<Recipe>.GetByIdAsync(Guid id, bool readOnly)
        {
            throw new NotImplementedException();
        }

        Task IRecipeRepository.UpdateAsync(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
