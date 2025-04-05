using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Application.Ingredients.GetIngredients;
using NutritionalKitchen.Application.Recipe.GetRecipe;
using NutritionalKitchen.Infraestructura.StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura.Handlers
{
    public class GetRecipeHandler : IRequestHandler<GetRecipeQuery, IEnumerable<RecipeDto>>
    {
        private readonly StoredDbContext _dbContext;

        public GetRecipeHandler(StoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<RecipeDto>> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Recipe.AsNoTracking().
            Select(i => new RecipeDto()
            {
                Id = i.Id,
                Name = i.Name,
                PreparationTime = i.PreparationTime
            }).
            ToListAsync(cancellationToken);
        }
    }
}
