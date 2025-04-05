using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.KitchenManager
{
    public class KitchenManagerFactory : IKitchenManagerFactory
    {
        public KitchenManager Create(Guid id, string name, string shift)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id is required", nameof(id));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is required", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(shift))
            {
                throw new ArgumentException("Shift is required", nameof(shift));
            }

            return new KitchenManager(id, name, shift);
        }
    }

}
