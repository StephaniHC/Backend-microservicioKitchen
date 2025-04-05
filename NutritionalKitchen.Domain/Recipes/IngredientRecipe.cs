using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Domain.Recipe
{
    public class IngredientRecipe : AggregateRoot
    {
        public Guid Id { get; private set; }
        public double Quantity { get; private set; }
        public string MeasureUnit { get; private set; }
        public Guid RecipeId { get; private set; }
        public Guid IngredientId { get; private set; }

        public IngredientRecipe(Guid id, double quantity, string measureUnit, Guid recipeId, Guid ingredientId)
            : base(Guid.NewGuid()) 
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El Id no puede estar vacío", nameof(id));

            if (quantity <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero", nameof(quantity));

            if (string.IsNullOrWhiteSpace(measureUnit))
                throw new ArgumentException("La unidad de medida no puede estar vacía.", nameof(measureUnit));

            if (recipeId == Guid.Empty)
                throw new ArgumentException("El Id de la receta no puede estar vacío", nameof(recipeId));

            if (ingredientId == Guid.Empty)
                throw new ArgumentException("El Id del ingrediente no puede estar vacío", nameof(ingredientId));

            Id = id;
            Quantity = quantity;
            MeasureUnit = measureUnit;
            RecipeId = recipeId;
            IngredientId = ingredientId;
        }
         
        public void UpdateQuantity(double newQuantity)
        {
            if (newQuantity <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero.", nameof(newQuantity));

            Quantity = newQuantity;
        }
         
        public void UpdateMeasureUnit(string measureUnit)
        {
            if (string.IsNullOrWhiteSpace(measureUnit))
                throw new ArgumentException("La unidad de medida no puede estar vacía.", nameof(measureUnit));

            MeasureUnit = measureUnit;
        }
    }
}
