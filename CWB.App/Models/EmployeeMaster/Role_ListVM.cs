using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.App.Models.EmployeeMaster
{
    public class Role_ListVM
    {
        public long Role_ListId { get; set; }
        public string Role_Desc { get; set; }
        public string Work_Done { get; set; }
        public long TenantId { get; set; }
    }
}
