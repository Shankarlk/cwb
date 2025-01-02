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
    public class Org_ChartConfiguration : IEntityTypeConfiguration<Org_Chart>
    {
        public void Configure(EntityTypeBuilder<Org_Chart> builder)
        {
            builder
            .ToTable("Org_Chart");
            builder
               .HasKey(c => c.Id);
            builder
                .Property(t => t.First_node)
                .HasColumnName("First_node");
            builder
                .Property(t => t.Role_Name)
                .HasColumnName("Role_Name")
                .IsRequired();
            builder
                .Property(t => t.Dept_ID)
                .HasColumnName("Dept_ID");
            builder
                .Property(c => c.location_id)
                .HasColumnName("location_id");
            builder
                .Property(c => c.Reporting_to)
                .HasColumnName("Reporting_to");
            builder
                .Property(c => c.Employee_Id)
                .HasColumnName("Employee_Id");
            builder
                .Property(c => c.Level_No)
                .HasColumnName("Level_No");
            builder
                .Property(c => c.Self_Comp_Id)
                .HasColumnName("Self_Comp_Id");
            builder
                .Property(c => c.Admin_Flag)
                .HasColumnName("Admin_Flag");
            builder
                .Property(c => c.TenantId)
                .HasColumnName("TenantId")
                .IsRequired();
            builder.ConfigureBase();
            builder.HasIndex(c => c.TenantId).HasDatabaseName("Org_Chart_TenantId");
        }
    }
}
