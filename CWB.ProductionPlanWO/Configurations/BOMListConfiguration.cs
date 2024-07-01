using CWB.CommonUtils.Common.Configurations;
using CWB.ProductionPlanWO.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.ProductionPlanWO.Configurations
{
    public class BOMListConfiguration : IEntityTypeConfiguration<BOMList>
    {
        public void Configure(EntityTypeBuilder<BOMList> builder)
        {
            builder
                .ToTable("BOMList");
            builder
                .HasKey(b => b.Id);
            builder
                .Property(b => b.ParentWoId)
                .HasColumnName("ParentWoId");
            builder
                .Property(b => b.ChildWoId)
                .HasColumnName("ChildWoId");
            builder
                .Property(b => b.ProcPlanId)
                .HasColumnName("ProcPlanId");
            builder
                .Property(b => b.TestData)
                .HasColumnName("TestData");
            builder
                .Property(b => b.SaNestLevel)
                .HasColumnName("SaNestLevel");
            builder
                .Property(c => c.TenantId)
                .HasColumnName("TenantId")
                .IsRequired();
            builder.ConfigureBase();
            builder.HasIndex(c => c.TenantId).HasDatabaseName("BOMList_TenantId");
        }
    }
}
