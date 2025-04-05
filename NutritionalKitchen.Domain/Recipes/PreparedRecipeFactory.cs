using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Recipe
{
    public class PreparedRecipeFactory : IPreparedRecipeFactory
    {
        public PreparedRecipe Create(Guid id, DateTime date, bool status, Guid kitchenManagerId, Guid recipeId)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id is required", nameof(id));
            }

            if (date == default)
            {
                throw new ArgumentException("Date is required", nameof(date));
            }

            if (kitchenManagerId == Guid.Empty)
            {
                throw new ArgumentException("Kitchen manager ID is required", nameof(kitchenManagerId));
            }

            if (recipeId == Guid.Empty)
            {
                throw new ArgumentException("Recipe ID is required", nameof(recipeId));
            }

            return new PreparedRecipe(id, date, status, kitchenManagerId, recipeId);
        }
    }

}
