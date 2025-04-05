using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Infraestructura.StoredModel.Entities;

using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura.StoredModel
{
    public class StoredDbContext : DbContext
    {
        public virtual DbSet<IngredientsStoredModel> Ingredients { get; set; }
        public virtual DbSet<PackageStoredModel> Package { get; set; }
        public virtual DbSet<KitchenManagerStoredModel> KitchenManager { get; set; }
        public virtual DbSet<LabelStoredModel> Label { get; set; }
        public virtual DbSet<RecipeStoredModel> Recipe { get; set; }

        public StoredDbContext(DbContextOptions<StoredDbContext> options) : base(options)
        {

        }
    }
}
