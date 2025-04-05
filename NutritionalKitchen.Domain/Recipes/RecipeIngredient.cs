using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.Shared;

public class RecipeIngredient : AggregateRoot
{
    public QuantityValue Quantity { get; private set; }
    public string UnitOfMeasure { get; private set; }
    public Guid RecipeId { get; private set; }
    public Guid IngredientId { get; private set; }

    public RecipeIngredient(QuantityValue value, string unitOfMeasure, Guid recipeId, Guid ingredientId) : base(Guid.NewGuid())
    { 
        Quantity = value ?? throw new ArgumentException("La cantidad debe ser mayor a cero.");
        UnitOfMeasure = unitOfMeasure;
        RecipeId = recipeId;
        IngredientId = ingredientId;
    }

    public void UpdateQuantity(QuantityValue value)
    { 
        if (value == null || value.Value <= 0)
            throw new ArgumentException("La cantidad debe ser mayor a cero.");

        Quantity = value;
    }

    public void UpdateUnitOfMeasure(string newUnitOfMeasure)
    {
        if (string.IsNullOrWhiteSpace(newUnitOfMeasure))
            throw new ArgumentException("La unidad de medida no puede estar vacía.");
        UnitOfMeasure = newUnitOfMeasure;
    }
}
