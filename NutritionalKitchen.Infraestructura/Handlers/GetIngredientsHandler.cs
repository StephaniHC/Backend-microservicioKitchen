using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Application.Ingredients.GetIngredients;
using NutritionalKitchen.Infraestructura.StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 


namespace NutritionalKitchen.Infraestructura.Handlers
{
    public class GetIngredientsHandler : IRequestHandler<GetIngredientsQuery, IEnumerable<IngredientDto>>
    {
        private readonly StoredDbContext _dbContext;

        public GetIngredientsHandler(StoredDbContext dbContext)
        {
            _dbContext = dbContext;
        } 

        public async Task<IEnumerable<IngredientDto>> Handle(GetIngredientsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Ingredients.AsNoTracking().
            Select(i => new IngredientDto()
            {
                Id = i.Id,
                Name = i.Name
            }).
            ToListAsync(cancellationToken);
        }
    }
}
