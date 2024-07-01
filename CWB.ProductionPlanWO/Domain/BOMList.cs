using CWB.CommonUtils.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.ProductionPlanWO.Domain
{
    public class BOMList : BaseEntity
    {
        public long ParentWoId { get; set; }
        public long ChildWoId { get; set; }
        public long ProcPlanId { get; set; }
        public char TestData { get; set; }
        public long SaNestLevel { get; set; }
        public long TenantId { get; set; }
    }
}
