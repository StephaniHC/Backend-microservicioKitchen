using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Recipe
{
    public class PreparedRecipe : AggregateRoot
    {
        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public bool Status { get; private set; }
        public Guid KitchenManagerId { get; private set; }
        public Guid RecipeId { get; private set; }
        public PreparedRecipe(Guid id, DateTime date, bool status, Guid kitchenManagerId, Guid recipeId) : base(Guid.NewGuid())
        {
            Id = id;
            Date = date;
            Status = status;
            KitchenManagerId = kitchenManagerId;
            RecipeId = recipeId;
        }
        public void UpdateStatus(bool newStatus)
        {
            Status = newStatus;
        }

        public void UpdateDate(DateTime newDate)
        {
            if (newDate > DateTime.UtcNow)
                throw new ArgumentException("La fecha no puede estar en el futuro.");
            Date = newDate;
        }
    }
}
