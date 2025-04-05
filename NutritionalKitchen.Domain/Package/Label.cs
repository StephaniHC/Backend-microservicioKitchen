using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Package
{
    public class Label : AggregateRoot
    {
        public Guid BatchCode { get; private set; }
        public DateTime ProductionDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public string Detail { get; private set; }
        public string Address { get; private set; }
        public Guid PatientId { get; private set; }
        public Label(Guid batchCode, DateTime productionDate, DateTime expirationDate, string detail, string address, Guid patientId) : base(Guid.NewGuid())
        {
            BatchCode = batchCode;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
            Detail = detail;
            Address = address;
            PatientId = patientId;
        }

        public void UpdateDetail(string newDetail)
        {
            if (string.IsNullOrWhiteSpace(newDetail))
                throw new ArgumentException("El detalle no puede estar vacío.");
            Detail = newDetail;
        }
        public void UpdateAddress(string newAddress)
        {
            if (string.IsNullOrWhiteSpace(newAddress))
                throw new ArgumentException("La dirección no puede estar vacía.");
            Address = newAddress;
        } 
        public void UpdateDates(DateTime newProductionDate, DateTime newExpirationDate)
        {
            if (newExpirationDate <= newProductionDate)
                throw new ArgumentException("La fecha de expiración debe ser posterior a la fecha de producción.");
            ProductionDate = newProductionDate;
            ExpirationDate = newExpirationDate;
        }

    }
}
