using MediatR;
using Microsoft.EntityFrameworkCore; 
using NutritionalKitchen.Application.Label.GetLabel;
using NutritionalKitchen.Infraestructura.StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura.Handlers
{
    public class GetLabelHandler : IRequestHandler<GetLabelQuery, IEnumerable<LabelDto>>
    {
        private readonly StoredDbContext _dbContext;

        public GetLabelHandler(StoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<LabelDto>> Handle(GetLabelQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Label.AsNoTracking().
            Select(i => new LabelDto()
            {
                BatchCode = i.BatchCode, 
                ProductionDate = i.ProductionDate,
                ExpirationDate = i.ExpirationDate,
                Detail = i.Detail,
                Address = i.Address,
                PatientId = i.PatientId
            }).ToListAsync(cancellationToken);
        }
    }
}
