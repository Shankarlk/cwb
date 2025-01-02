using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.App.Models.EmployeeMaster
{
    public class Permission_ListVM
    {
        public long PermissionId { get; set; }
        public string Permission { get; set; }
        public long TenantId { get; set; }
    }
}
