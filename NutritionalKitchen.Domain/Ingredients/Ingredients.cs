using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Ingredients
{
    public class Ingredients : AggregateRoot
    { 
        public string Name { get; private set; }
        public Ingredients(Guid id, string name ) : base(id)
        {
            Id = Id;
            Name = name; 
        }
        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("El nombre del ingrediente no puede estar vacío.");
            Name = newName;
        }
    }
}
