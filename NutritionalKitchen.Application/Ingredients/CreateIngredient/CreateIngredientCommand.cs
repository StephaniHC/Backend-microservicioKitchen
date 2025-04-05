using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Ingredients.CreateIngredient
{
    public record CreateIngredientCommand(Guid id, string name) : IRequest<Guid>
    { 
    }
}
