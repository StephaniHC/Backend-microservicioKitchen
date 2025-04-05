using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Recipe
{
    public class IngredientRecipeFactory : IIngredientRecipeFactory
    {
        public IngredientRecipe Create(Guid id, double quantity, string measureUnit, Guid recipeId, Guid ingredientId)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id is required", nameof(id));
            }

            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero", nameof(quantity));
            }

            if (string.IsNullOrWhiteSpace(measureUnit))
            {
                throw new ArgumentException("Measure unit is required", nameof(measureUnit));
            }

            if (recipeId == Guid.Empty)
            {
                throw new ArgumentException("Recipe ID is required", nameof(recipeId));
            }

            if (ingredientId == Guid.Empty)
            {
                throw new ArgumentException("Ingredient ID is required", nameof(ingredientId));
            }

            return new IngredientRecipe(id, quantity, measureUnit, recipeId, ingredientId);
        }
    }

}
