using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.Ingredients;
using NutritionalKitchen.Domain.KitchenManager;
using NutritionalKitchen.Domain.Package;
using NutritionalKitchen.Infraestructura.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura.Repositories
{
    public class KitchenManagerRepository : IKitchenManagerRepository
    {
        private readonly DomainDbContext _dbContext;

        public KitchenManagerRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }
         
        public async Task AddAsync(KitchenManager entity)
        {
            await _dbContext.KitchenManager.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<KitchenManager?> IRepository<KitchenManager>.GetByIdAsync(Guid id, bool readOnly)
        {
            throw new NotImplementedException();
        }

        Task IKitchenManagerRepository.UpdateAsync(KitchenManager kitchenManager)
        {
            throw new NotImplementedException();
        }
    }
}
