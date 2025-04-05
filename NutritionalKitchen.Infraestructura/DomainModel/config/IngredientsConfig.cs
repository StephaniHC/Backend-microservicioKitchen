using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Domain.Ingredients;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura.DomainModel.config
{ 
    public class IngredientsConfig : IEntityTypeConfiguration<Ingredients>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Ingredients> builder)
        {
            builder.ToTable("ingredients");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Name)
                .HasColumnName("Name");
             
        }
    }
}
