using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Domain.Ingredients;
using NutritionalKitchen.Domain.Package;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura.DomainModel.config
{ 
    public class PackageConfig : IEntityTypeConfiguration<Package>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Package> builder)
        {
            builder.ToTable("package");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Status)
                .HasColumnName("Status");

            builder.Property(x => x.PreparedRecipeId)
                .HasColumnName("PreparedRecipeId");

            builder.Property(x => x.BatchCode)
                .HasColumnName("BatchCode");

        }
    }
}
