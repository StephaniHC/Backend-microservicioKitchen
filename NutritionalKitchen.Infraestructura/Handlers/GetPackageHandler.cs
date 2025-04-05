using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Application.Package.GetPackages;
using NutritionalKitchen.Infraestructura.StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura.Handlers
{
    public class GetPackageHandler : IRequestHandler<GetPackageQuery, IEnumerable<PackageDto>>
    {
        private readonly StoredDbContext _dbContext;

        public GetPackageHandler(StoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PackageDto>> Handle(GetPackageQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Package.AsNoTracking().
            Select(i => new PackageDto()
            {
                Id = i.Id,
                Status = i.Status,
                PreparedRecipeId = i.PreparedRecipeId,
                BatchCode = i.BatchCode,
            }).
            ToListAsync(cancellationToken);
        }
         
    }
}
