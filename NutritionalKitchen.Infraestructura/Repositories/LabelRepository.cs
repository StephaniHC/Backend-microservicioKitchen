using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.Ingredients;
using NutritionalKitchen.Domain.Package;
using NutritionalKitchen.Infraestructura.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura.Repositories
{
    public class LabelRepository : ILabelRepository
    {
        private readonly DomainDbContext _dbContext;

        public LabelRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Label entity)
        {
            await _dbContext.Label.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<Label?> IRepository<Label>.GetByIdAsync(Guid id, bool readOnly)
        {
            throw new NotImplementedException();
        }

        Task ILabelRepository.UpdateAsync(Label label)
        {
            throw new NotImplementedException();
        }
    }
}
