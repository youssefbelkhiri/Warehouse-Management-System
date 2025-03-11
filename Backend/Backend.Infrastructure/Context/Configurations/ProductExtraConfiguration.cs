using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Context.Configurations
{
    public class ProductExtraConfiguration : IEntityTypeConfiguration<ProductExtra>
    {
        public void Configure(EntityTypeBuilder<ProductExtra> builder)
        {
            builder.HasKey(pe => pe.Id);
            builder.Property(pe => pe.Attribute).IsRequired().HasMaxLength(100);
            builder.Property(pe => pe.Value).IsRequired().HasMaxLength(255);

            builder.HasOne(pe => pe.Product)
                   .WithMany(p => p.ProductExtras)
                   .HasForeignKey(pe => pe.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
