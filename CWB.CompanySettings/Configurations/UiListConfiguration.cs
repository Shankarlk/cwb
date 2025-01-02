﻿using CWB.CommonUtils.Common.Configurations;
using CWB.CompanySettings.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.CompanySettings.Configurations
{
    public class UiListConfiguration : IEntityTypeConfiguration<UiList>
    {
        public void Configure(EntityTypeBuilder<UiList> builder)
        {
            builder
            .ToTable("UiList");
            builder
               .HasKey(c => c.Id);
            builder
                .Property(t => t.MenuLevelId)
                .HasColumnName("MenuLevelId")
                .IsRequired();
            builder
                .Property(t => t.TopLevel)
                .HasColumnName("Top_evel")
                .IsRequired();
            builder
                .Property(t => t.UI_Type)
                .HasColumnName("UI_Type")
                .IsRequired();
            builder
                .Property(c => c.UI_Name_Label)
                .HasColumnName("UI_Name_Label");
            builder
                .Property(c => c.UI_Part_linked_to)
                .HasColumnName("UI_Part_linked_to");
            builder
                .Property(c => c.Approval_Allowed)
                .HasColumnName("Approval_Allowed")
                .HasDefaultValue('N');
            builder
                .Property(c => c.View_Allowed)
                .HasColumnName("View_Allowed");
            builder
                .Property(c => c.Add_Edit_Allowed)
                .HasColumnName("Add_Edit_Allowed");
            builder
                .Property(c => c.Delete_Allowed)
                .HasColumnName("Delete_Allowed");
            builder
                .Property(c => c.TenantId)
                .HasColumnName("TenantId")
                .IsRequired();
            builder.ConfigureBase();
            builder.HasData(
    new UiList { Id = 1, MenuLevelId = 1, TopLevel = 'Y', UI_Type = "Landing Page", UI_Name_Label = "Masters", UI_Part_linked_to = 0, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 2, MenuLevelId = 2, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Item Masters", UI_Part_linked_to = 1, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'Y', Delete_Allowed = 'Y', TenantId = 1 },
    new UiList { Id = 3, MenuLevelId = 3, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "View / Edit Part No", UI_Part_linked_to = 2, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'Y', Delete_Allowed = 'Y', TenantId = 1 },
    new UiList { Id = 4, MenuLevelId = 4, TopLevel = 'N', UI_Type = "Command", UI_Name_Label = "Edit Part", UI_Part_linked_to = 3, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'Y', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 8, MenuLevelId = 3, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Create New Manf Part No", UI_Part_linked_to = 2, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'Y', Delete_Allowed = 'Y', TenantId = 1 },
    new UiList { Id = 9, MenuLevelId = 4, TopLevel = 'N', UI_Type = "Tab", UI_Name_Label = "Basic Information Tab", UI_Part_linked_to = 8, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 10, MenuLevelId = 4, TopLevel = 'N', UI_Type = "Tab", UI_Name_Label = "Document Upload Grid", UI_Part_linked_to = 8, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList
    {
        Id = 11,
        MenuLevelId = 4,
        TopLevel = 'N',
        UI_Type = "Tab",
        UI_Name_Label = "Make From Tab - if Part Type = Manuf Child Part",
        UI_Part_linked_to = 8,
        Approval_Allowed = 'N',
        View_Allowed = 'Y',
        Add_Edit_Allowed = 'N',
        Delete_Allowed = 'N',
        TenantId = 1,
    },
            new UiList
            {
                Id = 12,
                MenuLevelId = 4,
                TopLevel = 'N',
                UI_Type = "Landing Page",
                UI_Name_Label = "BOM Tab - if Part Type = Assembly",
                UI_Part_linked_to = 8,
                Approval_Allowed = 'N',
                View_Allowed = 'Y',
                Add_Edit_Allowed = 'N',
                Delete_Allowed = 'N',
                TenantId = 1,
            },
            new UiList
            {
                Id = 13,
                MenuLevelId = 3,
                TopLevel = 'N',
                UI_Type = "Landing Page",
                UI_Name_Label = "Create New Raw Material Part No",
                UI_Part_linked_to = 2,
                Approval_Allowed = 'N',
                View_Allowed = 'Y',
                Add_Edit_Allowed = 'N',
                Delete_Allowed = 'N',
                TenantId = 1,
            },
            new UiList
            {
                Id = 14,
                MenuLevelId = 4,
                TopLevel = 'N',
                UI_Type = "Tab",
                UI_Name_Label = "Part Info",
                UI_Part_linked_to = 13,
                Approval_Allowed = 'N',
                View_Allowed = 'Y',
                Add_Edit_Allowed = 'N',
                Delete_Allowed = 'N',
                TenantId = 1,
            },
            new UiList
            {
                Id = 15,
                MenuLevelId = 4,
                TopLevel = 'N',
                UI_Type = "Landing Page",
                UI_Name_Label = "Document Upload Grid",
                UI_Part_linked_to = 13,
                Approval_Allowed = 'N',
                View_Allowed = 'Y',
                Add_Edit_Allowed = 'N',
                Delete_Allowed = 'N',
                TenantId = 1,
            },
            new UiList
            {
                Id = 16,
                MenuLevelId = 4,
                TopLevel = 'N',
                UI_Type = "Landing Page",
                UI_Name_Label = "Purchase Details",
                UI_Part_linked_to = 13,
                Approval_Allowed = 'N',
                View_Allowed = 'Y',
                Add_Edit_Allowed = 'N',
                Delete_Allowed = 'N',
                TenantId = 1,
            },
    new UiList { Id = 17, MenuLevelId = 5, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Add / Edit Purchase Details", UI_Part_linked_to = 16, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 18, MenuLevelId = 3, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Create New Bof Part No", UI_Part_linked_to = 2, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 19, MenuLevelId = 4, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Part Info", UI_Part_linked_to = 18, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 20, MenuLevelId = 4, TopLevel = 'N', UI_Type = "Tab", UI_Name_Label = "Document Upload Grid", UI_Part_linked_to = 18, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 21, MenuLevelId = 4, TopLevel = 'N', UI_Type = "Tab", UI_Name_Label = "Purchase Details", UI_Part_linked_to = 18, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 22, MenuLevelId = 5, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Add / Edit Purchase Details", UI_Part_linked_to = 21, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 23, MenuLevelId = 2, TopLevel = 'N', UI_Type = "Tab", UI_Name_Label = "Routing", UI_Part_linked_to = 1, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 24, MenuLevelId = 3, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Create New Routing / Edit", UI_Part_linked_to = 23, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 25, MenuLevelId = 4, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Page 1 - Routing List", UI_Part_linked_to = 24, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 26, MenuLevelId = 5, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Create New Routing", UI_Part_linked_to = 25, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 27, MenuLevelId = 4, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Page 2 - Details of Routing", UI_Part_linked_to = 24, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 28, MenuLevelId = 5, TopLevel = 'N', UI_Type = "Tab", UI_Name_Label = "Add Next Step / Edit", UI_Part_linked_to = 27, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 29, MenuLevelId = 4, TopLevel = 'N', UI_Type = "Tab", UI_Name_Label = "Page 3 - Details of Step", UI_Part_linked_to = 24, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 30, MenuLevelId = 5, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Step Basic Info", UI_Part_linked_to = 29, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 31, MenuLevelId = 5, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Add Subcon", UI_Part_linked_to = 29, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 33, MenuLevelId = 5, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Add Machine", UI_Part_linked_to = 29, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 34, MenuLevelId = 5, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Document Upload Grid", UI_Part_linked_to = 29, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 35, MenuLevelId = 5, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "if Part Type = Assembly List of Parts and Add BOM Parts Assembled / Used in this step", UI_Part_linked_to = 29, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 36, MenuLevelId = 2, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Machine List", UI_Part_linked_to = 1, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 37, MenuLevelId = 3, TopLevel = 'N', UI_Type = "Popup", UI_Name_Label = "Add Machine Details", UI_Part_linked_to = 36, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 }
, new UiList { Id = 38, MenuLevelId = 4, TopLevel = 'N', UI_Type = "Tab", UI_Name_Label = "General Tab", UI_Part_linked_to = 37, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 39, MenuLevelId = 5, TopLevel = 'N', UI_Type = "Tab", UI_Name_Label = "Machine Type Popup - Documents Types to be uploaded for this M/c Type", UI_Part_linked_to = 38, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 40, MenuLevelId = 4, TopLevel = 'N', UI_Type = "Tab", UI_Name_Label = "Process Document List Tab", UI_Part_linked_to = 37, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 41, MenuLevelId = 5, TopLevel = 'N', UI_Type = "Tab", UI_Name_Label = "Process Document required for Machine", UI_Part_linked_to = 40, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 43, MenuLevelId = 3, TopLevel = 'N', UI_Type = "Popup", UI_Name_Label = "Edit Machine Details", UI_Part_linked_to = 36, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 44, MenuLevelId = 2, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Operation List", UI_Part_linked_to = 1, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 45, MenuLevelId = 3, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Add Operation", UI_Part_linked_to = 44, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 46, MenuLevelId = 4, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Document Required for the Operation", UI_Part_linked_to = 45, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 47, MenuLevelId = 3, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Edit Operation", UI_Part_linked_to = 44, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 48, MenuLevelId = 4, TopLevel = 'N', UI_Type = "Tab", UI_Name_Label = "Document Required for the Operation", UI_Part_linked_to = 47, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
      new UiList { Id = 49, MenuLevelId = 2, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Contacts", UI_Part_linked_to = 1, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 50, MenuLevelId = 3, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Add / Edit Company", UI_Part_linked_to = 49, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 51, MenuLevelId = 2, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Doc Mgt", UI_Part_linked_to = 1, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 52, MenuLevelId = 3, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Add / Edit Document Type", UI_Part_linked_to = 51, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 53, MenuLevelId = 4, TopLevel = 'N', UI_Type = "Popup", UI_Name_Label = "File Extension List Add / Update", UI_Part_linked_to = 52, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 54, MenuLevelId = 3, TopLevel = 'N', UI_Type = "Popup", UI_Name_Label = "View Documents", UI_Part_linked_to = 51, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 55, MenuLevelId = 1, TopLevel = 'Y', UI_Type = "Landing Page", UI_Name_Label = "Company Settings", UI_Part_linked_to = 0, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 56, MenuLevelId = 2, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Location Details", UI_Part_linked_to = 55, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 57, MenuLevelId = 3, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Add / Edit Location", UI_Part_linked_to = 56, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 58, MenuLevelId = 2, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Organization", UI_Part_linked_to = 55, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
     new UiList { Id = 59, MenuLevelId = 3, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Add / Edit Department", UI_Part_linked_to = 58, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 60, MenuLevelId = 2, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Designation List", UI_Part_linked_to = 55, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 61, MenuLevelId = 3, TopLevel = 'N', UI_Type = "Popup", UI_Name_Label = "Add / Edit Designation", UI_Part_linked_to = 60, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 62, MenuLevelId = 1, TopLevel = 'Y', UI_Type = "Landing Page", UI_Name_Label = "Business Process", UI_Part_linked_to = 0, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 63, MenuLevelId = 2, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Business Acquisition", UI_Part_linked_to = 62, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 64, MenuLevelId = 3, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Order Entry", UI_Part_linked_to = 63, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 65, MenuLevelId = 2, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Process Planning", UI_Part_linked_to = 62, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 66, MenuLevelId = 3, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Convert SO to WO", UI_Part_linked_to = 65, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 67, MenuLevelId = 4, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Edit WO", UI_Part_linked_to = 66, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 68, MenuLevelId = 3, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Detailed Production Planning", UI_Part_linked_to = 65, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 69, MenuLevelId = 4, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Edit Production WO", UI_Part_linked_to = 68, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 70, MenuLevelId = 3, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "SO List / View", UI_Part_linked_to = 65, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 71, MenuLevelId = 4, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Edit SO", UI_Part_linked_to = 70, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 72, MenuLevelId = 3, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Work Order List View", UI_Part_linked_to = 65, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 },
    new UiList { Id = 73, MenuLevelId = 4, TopLevel = 'N', UI_Type = "Landing Page", UI_Name_Label = "Edit WO", UI_Part_linked_to = 72, Approval_Allowed = 'N', View_Allowed = 'Y', Add_Edit_Allowed = 'N', Delete_Allowed = 'N', TenantId = 1 }


    );
            builder.HasIndex(c => c.TenantId).HasDatabaseName("UiList_TenantId");
        }
    }
}
