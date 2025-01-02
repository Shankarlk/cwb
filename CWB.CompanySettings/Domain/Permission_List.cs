using CWB.CommonUtils.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.CompanySettings.Domain
{
    public class Permission_List : BaseEntity
    {
        public string Permission { get; set; }
        public long TenantId { get; set; }
    }
}
