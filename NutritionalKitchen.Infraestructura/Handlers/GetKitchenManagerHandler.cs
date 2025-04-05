using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Application.KitchenManager.GetKitchenManager;
using NutritionalKitchen.Infraestructura.StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura.Handlers
{
    public class GetKitchenManagerHandler : IRequestHandler<GetKitchenManagerQuery, IEnumerable<KitchenManagerDto>>
    {
        private readonly StoredDbContext _dbContext;

        public GetKitchenManagerHandler(StoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<KitchenManagerDto>> Handle(GetKitchenManagerQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.KitchenManager.AsNoTracking().
            Select(i => new KitchenManagerDto()
            {
                Id = i.Id,
                Name = i.Name,
                Shift = i.Shift
            }).
            ToListAsync(cancellationToken);
        }
    }
}
