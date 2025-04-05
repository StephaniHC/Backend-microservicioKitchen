using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NutritionalKitchen.Domain.Package;
using NutritionalKitchen.Domain.Recipe;
using NutritionalKitchen.Infraestructura.DomainModel;
using NutritionalKitchen.Infraestructura.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalKitchen.Test.Infraestructura.Repositories
{
    public class RecipeRepositoryTest
    {
        private readonly Mock<DomainDbContext> _dbContext;
        private readonly Mock<DbSet<Recipe>> _recipeDbSet;
        private readonly RecipeRepository _repository;

        public RecipeRepositoryTest()
        {

            var options = new DbContextOptions<DomainDbContext>();
            _dbContext = new Mock<DomainDbContext>(options);

            _recipeDbSet = new Mock<DbSet<Recipe>>();
            _dbContext.Setup(x => x.Set<Recipe>()).Returns(_recipeDbSet.Object);
            _dbContext.Setup(x => x.Recipe).ReturnsDbSet(new List<Recipe>());

            _repository = new RecipeRepository(_dbContext.Object); 
             
        }

        [Fact]
        public async Task AddAsync_ShouldAddRecipe()
        {
            var recipe = new Recipe(Guid.NewGuid(), "Test Recipe", "Description");

            // Act
            await _repository.AddAsync(recipe);

            // Assert
            _recipeDbSet.Verify(db => db.AddAsync(recipe, It.IsAny<CancellationToken>()), Times.Once);
            _dbContext.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once); 
             
        }
    }
}
