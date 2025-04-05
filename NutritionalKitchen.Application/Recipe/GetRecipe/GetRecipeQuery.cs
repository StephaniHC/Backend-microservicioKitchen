using MediatR;
using NutritionalKitchen.Application.Label.GetLabel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Recipe.GetRecipe
{ 
    public record GetRecipeQuery(string SearchTerm) : IRequest<IEnumerable<RecipeDto>>;
}
