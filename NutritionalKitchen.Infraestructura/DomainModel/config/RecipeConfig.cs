using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Domain.Recipe;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura.DomainModel.config
{ 
    public class RecipeConfig : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("recipe");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Name)
                .HasColumnName("Name");

            builder.Property(x => x.PreparationTime)
                .HasColumnName("PreparationTime");
        }
    }
}
