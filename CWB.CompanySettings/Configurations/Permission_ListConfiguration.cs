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
    public class Permission_ListConfiguration : IEntityTypeConfiguration<Permission_List>
    {
        public void Configure(EntityTypeBuilder<Permission_List> builder)
        {
            builder
            .ToTable("Permission_List");
            builder
               .HasKey(c => c.Id);
            builder
                .Property(t => t.Permission)
                .HasColumnName("Permission")
                .IsRequired();
            builder
                .Property(c => c.TenantId)
                .HasColumnName("TenantId")
                .IsRequired();
            builder.HasData(
          new Permission_List { Id = 1, Permission = "None", TenantId = 1 },
          new Permission_List { Id = 2, Permission = "View", TenantId = 1 },
          new Permission_List { Id = 3, Permission = "Add-Edit", TenantId = 1 },
          new Permission_List { Id = 4, Permission = "Delete", TenantId = 1 },
          new Permission_List { Id = 5, Permission = "Approve", TenantId = 1 }
          );
            builder.ConfigureBase();
            builder.HasIndex(c => c.TenantId).HasDatabaseName("Permission_List_TenantId");
        }
    }
}
