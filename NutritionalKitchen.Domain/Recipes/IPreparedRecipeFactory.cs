using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Recipe
{
    public interface IPreparedRecipeFactory
    {
        PreparedRecipe Create(Guid id, DateTime date, bool status, Guid kitchenManagerId, Guid recipeId);
    }

}
