using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Recipe
{
    public class Recipe : AggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string PreparationTime { get; private set; }

        public Recipe(Guid id, string name, string preparationTime)
            : base(Guid.NewGuid())
        {
            Id = id;
            Name = name;
            PreparationTime = preparationTime;
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("El nombre no puede estar vacío.");
            Name = newName;
        }

        public void UpdatePreparationTime(string newPreparationTime)
        {
            if (string.IsNullOrWhiteSpace(newPreparationTime))
                throw new ArgumentException("El tiempo de preparación no puede estar vacío.");
            PreparationTime = newPreparationTime;
        }
    } 
}
