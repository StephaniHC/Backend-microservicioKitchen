using NutritionalKitchen.Domain.Ingredients;
using NutritionalKitchen.Infraestructura.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura.Repositories
{
    public class IngredientsRepository : IIngredientsRepository
    {
        private readonly DomainDbContext _dbContext;

        public IngredientsRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Ingredients entity)
        {
            await _dbContext.Ingredients.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.Ingredients.Remove(obj);
        }

        public async Task<Ingredients> GetByIdAsync(Guid id)
        {
            return await _dbContext.Ingredients.FindAsync(id);
        }

        public Task<Ingredients> GetByIdAsync(Guid id, bool readOnly = false)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Ingredients ingredient)
        {
            _dbContext.Ingredients.Update(ingredient);

            return Task.CompletedTask;
        }
    }
}
