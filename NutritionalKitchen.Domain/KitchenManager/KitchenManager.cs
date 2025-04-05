using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.KitchenManager
{
    public class KitchenManager : AggregateRoot
    { 
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Shift { get; private set; } 
          
        public KitchenManager(Guid id, string name, string shift) : base(Guid.NewGuid())
        {
            Id = id;
            Name = name;
            Shift = shift;
        }
        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("El nombre no puede estar vacío.");
            Name = newName;
        }

        public void UpdateShift(string newShift)
        {
            var validShifts = new[] { "Morning", "Afternoon", "Night" }; 
            if (!validShifts.Contains(newShift))
                throw new ArgumentException("El turno especificado no es válido.");
            Shift = newShift;
        }
    }
}
