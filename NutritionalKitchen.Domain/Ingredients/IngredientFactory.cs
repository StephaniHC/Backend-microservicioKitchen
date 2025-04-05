using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Ingredients
{
    public class IngredientFactory : IIngredientFactory
    {
        public Ingredients Create(Guid id, string name)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id is required", nameof(id));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Ingredient name is required", nameof(name));
            }

            return new Ingredients(id, name);
        }
    }
}
