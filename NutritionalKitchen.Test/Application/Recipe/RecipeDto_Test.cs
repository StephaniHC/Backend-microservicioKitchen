using NutritionalKitchen.Application.Recipe.GetRecipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Application.Recipe
{
    public class RecipeDto_Test
    {
        [Fact]
        public void RecipeDto_CheckPropertiesValid()
        { 
            Guid id = Guid.NewGuid();
            string name = "Spaghetti";
            string preparationTime = "30 minutes";
             
            RecipeDto recipeDto = new();
             
            Assert.Equal(Guid.Empty, recipeDto.Id);
            Assert.Null(recipeDto.Name);
            Assert.Null(recipeDto.PreparationTime);
             
            recipeDto.Id = id;
            recipeDto.Name = name;
            recipeDto.PreparationTime = preparationTime;
             
            Assert.Equal(id, recipeDto.Id);
            Assert.Equal(name, recipeDto.Name);
            Assert.Equal(preparationTime, recipeDto.PreparationTime);
        }
    }
}
