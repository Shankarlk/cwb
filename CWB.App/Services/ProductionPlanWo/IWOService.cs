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
    }
}
