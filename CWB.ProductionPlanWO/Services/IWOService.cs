using CWB.ProductionPlanWO.Domain;
using CWB.ProductionPlanWO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.ProductionPlanWO.Services
{
    public interface IWOService
    {
      Task<WorkOrdersVM> WorkOrder(WorkOrdersVM workOrdersVM);
      Task<IEnumerable<WorkOrdersVM>> AllWorkOrders(long tenantId);
      Task<IEnumerable<WOSOVM>> GetSoWo(long workOrderId);
      Task<WorkOrdersVM> GetSingleWO(long Id, long tenantId);
      Task<List<WorkOrdersVM>> MultipleWorkOrder(List<WorkOrdersVM> workOrdersVM);
      Task<List<WOSOVM>> PostWOSO(List<WOSOVM> woso);
       string HelloWorld();
    }
}
