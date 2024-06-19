﻿using CWB.CommonUtils.Common;
using System;

namespace CWB.ProductionPlanWO.Domain
{
    public class ProcPlan : BaseEntity
    {
        public string Reference { get; set; }
        public int TestData { get; set; }
        public int For_Ref { get; set; }
        public long PartId { get; set; }
        public int PartType { get; set; }
        public int Calc_Proc_Qnty { get; set; }
        public int QtyOnHand { get; set; }
        public int AddnOtyUser { get; set; }
        public int Plan_Proc_Qnty { get; set; }
        public DateTime PlanReceiptDate { get; set; }
        public DateTime CalcReceiptDate { get; set; }
        public int CriticalPart { get; set; }
        public int Changed { get; set; }
        public long TenantId { get; set; }
    }
}
