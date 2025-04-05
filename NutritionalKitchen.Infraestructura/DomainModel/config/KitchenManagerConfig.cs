using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Domain.Ingredients;
using NutritionalKitchen.Domain.KitchenManager;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura.DomainModel.config
{ 
    public class KitchenManagerConfig : IEntityTypeConfiguration<KitchenManager>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<KitchenManager> builder)
        {
            builder.ToTable("kitchenManager");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Name)
                .HasColumnName("Name");

            builder.Property(x => x.Shift)
                .HasColumnName("Shift");

        }
    }
}
