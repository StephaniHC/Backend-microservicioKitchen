using MediatR;
using NutritionalKitchen.Application.KitchenManager.GetKitchenManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Package.GetPackages
{ 
    public record GetPackageQuery(string SearchTerm) : IRequest<IEnumerable<PackageDto>>;
}
