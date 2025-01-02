using CWB.CommonUtils.Common.Configurations;
using CWB.CompanySettings.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.CompanySettings.Configurations
{
    public class Role_ListConfiguration : IEntityTypeConfiguration<Role_List>
    {
        public void Configure(EntityTypeBuilder<Role_List> builder)
        {
            builder
            .ToTable("Role_List");
            builder
               .HasKey(c => c.Id);
            builder
                .Property(t => t.Role_Desc)
                .HasColumnName("Role_Desc");
            builder
                .Property(t => t.Work_Done)
                .HasColumnName("Work_Done")
                .IsRequired();
            builder
                .Property(c => c.TenantId)
                .HasColumnName("TenantId")
                .IsRequired();
            builder.ConfigureBase();
            builder.HasIndex(c => c.TenantId).HasDatabaseName("Role_List_TenantId");
        }
    }
}
