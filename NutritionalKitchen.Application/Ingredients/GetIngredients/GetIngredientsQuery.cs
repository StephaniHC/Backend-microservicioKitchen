using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Ingredients.GetIngredients
{
    public record GetIngredientsQuery(string SearchTerm) : IRequest<IEnumerable<IngredientDto>>;
}
