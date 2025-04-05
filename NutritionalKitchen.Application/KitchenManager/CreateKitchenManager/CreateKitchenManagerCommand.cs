
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.KitchenManager.CreateKitchenManager
{ 
    public record CreateKitchenManagerCommand(Guid id, string name, string shift) : IRequest<Guid>;
}
