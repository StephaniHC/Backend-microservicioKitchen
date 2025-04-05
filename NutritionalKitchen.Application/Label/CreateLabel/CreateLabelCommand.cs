using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Label.CreateLabel
{ 
    public record CreateLabelCommand(Guid BatchCode, DateTime ProductionDate, DateTime ExpirationDate, string Detail, string Address, Guid PatientId) : IRequest<Guid>;
} 
 
 