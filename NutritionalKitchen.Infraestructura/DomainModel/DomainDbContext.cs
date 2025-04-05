using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Domain.Ingredients;
using NutritionalKitchen.Domain.KitchenManager;
using NutritionalKitchen.Domain.Package;
using NutritionalKitchen.Domain.Recipe;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura.DomainModel
{
    public class DomainDbContext : DbContext
    {
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<KitchenManager> KitchenManager { get; set; }
        public virtual DbSet<Label> Label { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }

        public DomainDbContext(DbContextOptions<DomainDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DomainDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
