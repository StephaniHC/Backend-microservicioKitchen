using NutritionalKitchen.Application.Ingredients.GetIngredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Application.Ingredients
{
    public class IngredientDto_Test
    {
        [Fact]
        public void IngredientDto_CheckPropertiesValid()
        { 
            Guid id = Guid.NewGuid();
            string name = "Tomato";
             
            IngredientDto ingredientDto = new();
             
            Assert.Equal(Guid.Empty, ingredientDto.Id);
            Assert.Null(ingredientDto.Name);
             
            ingredientDto.Id = id;
            ingredientDto.Name = name;
             
            Assert.Equal(id, ingredientDto.Id);
            Assert.Equal(name, ingredientDto.Name);
        }
    }
}
