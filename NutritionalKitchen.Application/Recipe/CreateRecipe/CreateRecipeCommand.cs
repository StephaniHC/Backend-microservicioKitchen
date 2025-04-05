using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Recipe.CreateRecipe
{ 
    public record CreateRecipeCommand(Guid Id, string Name, string PreparationTime) : IRequest<Guid>;
}
