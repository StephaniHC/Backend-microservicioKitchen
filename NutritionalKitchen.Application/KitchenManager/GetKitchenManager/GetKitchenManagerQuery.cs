using MediatR; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.KitchenManager.GetKitchenManager
{ 
    public record GetKitchenManagerQuery(string SearchTerm) : IRequest<IEnumerable<KitchenManagerDto>>;
}
