using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Ingredients
{
    public interface IIngredientFactory
    {
        Ingredients Create(Guid id, string name);
    }

}
