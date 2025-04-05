using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NutritionalKitchen.Domain.Ingredients;
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
    public class IngredientsRepositoryTest
    {
        private readonly Mock<DomainDbContext> _dbContext;
        private readonly IngredientsRepository _repository;
        private readonly Mock<DbSet<Ingredients>> _ingredientsDbSet;

        public IngredientsRepositoryTest()
        {
            var options = new Microsoft.EntityFrameworkCore.DbContextOptions<DomainDbContext>();
            _dbContext = new Mock<DomainDbContext>(options);

            // Mock del DbSet<Ingredients>
            _ingredientsDbSet = new Mock<DbSet<Ingredients>>();

            _dbContext.Setup(x => x.Ingredients).Returns(_ingredientsDbSet.Object);

            _repository = new IngredientsRepository(_dbContext.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldAddIngredient()
        {
            // Arrange
            var ingredient = new Ingredients ( Guid.NewGuid(),  "Salt"  );

            // Act
            await _repository.AddAsync(ingredient);

            // Assert
            _ingredientsDbSet.Verify(x => x.AddAsync(ingredient, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveIngredient_WhenIngredientExists()
        {
            // Arrange
            var ingredientId = Guid.NewGuid();
            var ingredient = new Ingredients ( ingredientId, "Sugar");

            _dbContext.Setup(x => x.Ingredients.FindAsync(ingredientId))
                .ReturnsAsync(ingredient);

            // Act
            await _repository.DeleteAsync(ingredientId);

            // Assert
            _dbContext.Verify(x => x.Ingredients.Remove(ingredient), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnIngredient_WhenIngredientExists()
        {
            // Arrange
            var ingredientId = Guid.NewGuid();
            var expectedIngredient = new Ingredients ( ingredientId,  "Flour");

            _dbContext.Setup(x => x.Ingredients.FindAsync(ingredientId))
                .ReturnsAsync(expectedIngredient);

            // Act
            var result = await _repository.GetByIdAsync(ingredientId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedIngredient.Id, result.Id);
            Assert.Equal(expectedIngredient.Name, result.Name);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateIngredient()
        {
            // Arrange
            var ingredient = new Ingredients ( Guid.NewGuid(), "Butter");

            // Act
            await _repository.UpdateAsync(ingredient);

            // Assert
            _dbContext.Verify(x => x.Ingredients.Update(ingredient), Times.Once);
        }
    }
}
