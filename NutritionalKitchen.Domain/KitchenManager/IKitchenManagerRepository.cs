using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.KitchenManager
{
    public interface IKitchenManagerRepository : IRepository<KitchenManager>
    {
        Task AddAsync(KitchenManager entity);
        Task UpdateAsync(KitchenManager kitchenManager);
        Task DeleteAsync(Guid id);
    }
}
