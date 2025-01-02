using CWB.CommonUtils.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.CompanySettings.Domain
{
    public class Role_List:BaseEntity
    {
        public string Role_Desc { get; set; }
        public string Work_Done { get; set; }
        public long TenantId { get; set; }
    }
}
