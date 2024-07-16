using CWB.App.Models.BusinessProcesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.App.Services.ProductionPlanWo
{
    public interface IWOService
    {
        Task<IEnumerable<WOSOVM>> GetSoWoRel(long workOrderId);
        Task<List<ProductionPlan_WoVM>> ProductionPlanWoPost(IEnumerable<ProductionPlan_WoVM> productions);
        Task<IEnumerable<ProductionPlan_WoVM>> AllProductionPlan_Wo();
        Task<List<ProcPlanVM>> ProcPlanPost(IEnumerable<ProcPlanVM> procPlans);
        Task<List<BOMListVM>> BomListPost(IEnumerable<BOMListVM> bomlist);
        Task<IEnumerable<ProcPlanVM>> GetAllProcPlan();
        Task<IEnumerable<BOMListVM>> GetAllBomlist();
    }
}
