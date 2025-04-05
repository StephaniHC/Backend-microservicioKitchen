using MediatR;
using NutritionalKitchen.Application.Ingredients.GetIngredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Label.GetLabel
{ 
    public record GetLabelQuery(string SearchTerm) : IRequest<IEnumerable<LabelDto>>;
}
