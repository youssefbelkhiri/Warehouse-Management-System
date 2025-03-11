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
    public class MovementLineDetailConfiguration : IEntityTypeConfiguration<MovementLineDetail>
    {
        public void Configure(EntityTypeBuilder<MovementLineDetail> builder)
        {
            builder.HasKey(mld => mld.Id);
            builder.Property(mld => mld.SerialNumber).IsRequired().HasMaxLength(100);
            builder.Property(mld => mld.ExpirationDate).IsRequired();

            builder.HasOne(mld => mld.MovementLine)
                   .WithMany(ml => ml.MovementLineDetails)
                   .HasForeignKey(mld => mld.MovementLineId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
