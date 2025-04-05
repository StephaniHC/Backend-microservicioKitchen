using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Recipe
{
    public interface IIngredientRecipeFactory
    {
        IngredientRecipe Create(Guid id, double quantity, string measureUnit, Guid recipeId, Guid ingredientId);
    }

}
