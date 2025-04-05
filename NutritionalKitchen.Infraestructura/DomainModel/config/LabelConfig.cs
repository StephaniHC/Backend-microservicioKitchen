using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Domain.KitchenManager;
using NutritionalKitchen.Domain.Package;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura.DomainModel.config
{ 
    public class LabelConfig : IEntityTypeConfiguration<Label>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Label> builder)
        {
            builder.ToTable("label");

            builder.HasKey(x => x.BatchCode);

            builder.Property(x => x.BatchCode)
                .HasColumnName("BatchCode");

            builder.Property(x => x.ProductionDate)
                .HasColumnName("ProductionDate");

            builder.Property(x => x.ExpirationDate)
                .HasColumnName("ExpirationDate");

            builder.Property(x => x.Detail)
                .HasColumnName("Detail");

            builder.Property(x => x.Address)
                .HasColumnName("Address");

            builder.Property(x => x.PatientId)
                .HasColumnName("PatientId");

        }
    } 
}