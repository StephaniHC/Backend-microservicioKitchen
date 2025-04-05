using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Recipe
{
    public class RecipeFactory : IRecipeFactory
    {
        public Recipe Create(Guid id, string name, string preparationTime)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id is required", nameof(id));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Recipe name is required", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(preparationTime))
            {
                throw new ArgumentException("Preparation time is required", nameof(preparationTime));
            }

            return new Recipe(id, name, preparationTime);
        }
    }

}
