using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.CompanySettings.ViewModels.EmployeeMaster
{
    public class Org_ChartVM
    {
        public long Org_ChartId { get; set; }
        public char First_node { get; set; }
        public long Role_NameId { get; set; }
        public long Dept_ID { get; set; }
        public long Location_id { get; set; }
        public long Reporting_to { get; set; }
        public long Employee_Id { get; set; }
        public long Level_No { get; set; }
        public long Self_Comp_Id { get; set; }
        public char Admin_Flag { get; set; }
        public long TenantId { get; set; }
    }
}
