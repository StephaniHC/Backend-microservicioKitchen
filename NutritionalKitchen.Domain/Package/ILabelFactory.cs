using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Package
{
    public interface ILabelFactory
    {
        Label Create(Guid batchCode, DateTime productionDate, DateTime expirationDate, string detail, string address, Guid patientId);
    }

}
