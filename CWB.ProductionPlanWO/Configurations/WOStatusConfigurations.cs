using CWB.ProductionPlanWO.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.ProductionPlanWO.Configurations
{
    public class WOStatusConfigurations:IEntityTypeConfiguration<WOStatus>
    {
        public void Configure(EntityTypeBuilder<WOStatus> builder)
        {
            builder
                .ToTable("WOStatus");
            builder
                .HasKey(c => c.Id);
            builder
                .Property(c => c.StatusId)
                .HasColumnName("StatusId");
            builder
                .Property(c => c.Status)
                .HasColumnName("Status")
                .IsRequired();
        }
    }
}
