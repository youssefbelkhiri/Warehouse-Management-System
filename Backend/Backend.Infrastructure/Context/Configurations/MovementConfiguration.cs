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
    public class MovementConfiguration : IEntityTypeConfiguration<Movement>
    {
        public void Configure(EntityTypeBuilder<Movement> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.MovementType).IsRequired().HasMaxLength(10);
            builder.Property(m => m.Date).IsRequired();
            builder.Property(m => m.TotalQuantity).IsRequired();

            builder.HasOne(m => m.Product)
                   .WithMany()
                   .HasForeignKey(m => m.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
