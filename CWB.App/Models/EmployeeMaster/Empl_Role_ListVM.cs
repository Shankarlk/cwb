using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.App.Models.EmployeeMaster
{
    public class Empl_Role_ListVM
    {
        public long Empl_Role_ListId { get; set; }
        public long EmployeeId { get; set; }
        public long Ui_Id { get; set; }
        public long PermissionId { get; set; }
        public long TenantId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string WorkDone { get; set; } = string.Empty;
        public string UiLevel { get; set; } = string.Empty;
        public string Approval_Allowed { get; set; } = string.Empty;
        public string View_Allowed { get; set; } = string.Empty;
        public string Add_Edit_Allowed { get; set; } = string.Empty;
        public string Delete_Allowed { get; set; } = string.Empty;
    }
}
