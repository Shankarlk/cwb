using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.CompanySettings.ViewModels.EmployeeMaster
{
    public class Role_UI_ListVM
    {
        public long Role_Ui_ListId { get; set; }
        public long Ui_Id { get; set; }
        public long RoleId { get; set; }
        public long PermissionId { get; set; }
        public long EmployeeId { get; set; }
        public string Comment { get; set; }
        public long TenantId { get; set; }
    }
}
