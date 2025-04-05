using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Package
{
    public class Package : AggregateRoot
    {
        public Guid Id { get; private set; }
        public string Status { get; private set; }
        public Guid PreparedRecipeId { get; private set; } 
        public string BatchCode { get; private set; } 
        public Package(Guid id, string status, Guid preparedRecipeId, string batchCode) : base(Guid.NewGuid())
        {
            Id = id;
            Status = status;
            PreparedRecipeId = preparedRecipeId;
            BatchCode = batchCode;
        } 

        public void UpdateStatus(string newStatus)
        {
            var validStatuses = new[] { "Pending", "InProgress", "Completed", "Canceled" }; 
            if (!validStatuses.Contains(newStatus))
                throw new ArgumentException("El estado especificado no es válido.");
            Status = newStatus;
        }
    }
}
