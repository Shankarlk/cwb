using CWB.CommonUtils.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.CompanySettings.Domain
{
    public class Org_Chart : BaseEntity
    {
        public char First_node { get; set; }
        public long Role_Name { get; set; }
        public long Dept_ID { get; set; }
        public long location_id { get; set; }
        public long Reporting_to { get; set; }
        public long Employee_Id { get; set; }
        public long Level_No { get; set; }
        public long Self_Comp_Id { get; set; }
        public char Admin_Flag { get; set; }
        public long TenantId { get; set; }
    }
}
