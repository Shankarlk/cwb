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
    public class Empl_Role_ListConfiguration : IEntityTypeConfiguration<Empl_Role_List>
    {
        public void Configure(EntityTypeBuilder<Empl_Role_List> builder)
        {
            builder
            .ToTable("Empl_Role_List");
            builder
               .HasKey(c => c.Id);
            builder
                .Property(t => t.EmployeeId)
                .HasColumnName("EmployeeId");
            builder
                .Property(t => t.Ui_Id)
                .HasColumnName("Ui_Id");
            builder
                .Property(t => t.PermissionId)
                .HasColumnName("PermissionId")
                .IsRequired();
            builder
                .Property(c => c.TenantId)
                .HasColumnName("TenantId")
                .IsRequired();
            builder.ConfigureBase();
            builder.HasIndex(c => c.TenantId).HasDatabaseName("Empl_Role_List_TenantId");
        }
    }
}
