using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.CompanySettings.ViewModels.EmployeeMaster
{
    public class Empl_Role_ListVM
    {
        public long Empl_Role_ListId { get; set; }
        public long Ui_Id { get; set; }
        public long EmployeeId { get; set; }
        public long PermissionId { get; set; }
        public long TenantId { get; set; }
    }
}
