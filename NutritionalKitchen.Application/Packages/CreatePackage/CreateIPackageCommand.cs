using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Package.CreatePackage
{ 
    public record CreateIPackageCommand(Guid id, string status, string BatchCode, Guid preparedRecipeId) : IRequest<Guid>;

}
 