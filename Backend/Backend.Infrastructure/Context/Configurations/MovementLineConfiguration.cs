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
    public class MovementLineConfiguration : IEntityTypeConfiguration<MovementLine>
    {
        public void Configure(EntityTypeBuilder<MovementLine> builder)
        {
            builder.HasKey(ml => ml.Id);
            builder.Property(ml => ml.Quantity).IsRequired();
            builder.Property(ml => ml.Unit).IsRequired().HasMaxLength(50);

            builder.HasOne(ml => ml.Movement)
                   .WithMany(m => m.MovementLines)
                   .HasForeignKey(ml => ml.MovementId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
