using AutoMapper;
using CWB.Logging;
using CWB.ProductionPlanWO.Domain;
using CWB.ProductionPlanWO.Infrastructure;
using CWB.ProductionPlanWO.Repositories;
using CWB.ProductionPlanWO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.ProductionPlanWO.Services
{
    public class WOService :IWOService
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWorkOrderRepository _workOrderRepository;
        private readonly IWOSORepository _wosoRepository;
        private readonly IProcPlanRepository _procPlanRepository;

        public WOService(
            ILoggerManager logger, IMapper mapper, IUnitOfWork unitOfWork
            , IWorkOrderRepository workOrderRepository
            , IProcPlanRepository procPlanRepository, IWOSORepository woso)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _workOrderRepository = workOrderRepository;
            _wosoRepository = woso;
            _procPlanRepository = procPlanRepository;
        }

        public string HelloWorld()
        {
            return "Hello World";
        }

        public async Task<WorkOrdersVM> WorkOrder(WorkOrdersVM workOrdersVM)
        {
            var wo = _mapper.Map<WorkOrders>(workOrdersVM);
            if (wo.SalesOrderId > 0)
            {
                if (wo.Id == 0)
                {
                    wo.WODate = DateTime.Now;
                    wo.WONumber = "WO_" + wo.WODate.Value.ToString("yyyyMMddHHmmssffff");
                    wo.Status = 1;
                    try
                    {
                        await _workOrderRepository.AddAsync(wo);
                    }
                    catch (Exception ex)
                    {
                        Exception exa = ex.InnerException;
                        string msg = ex.Message;
                    }
                }
                else
                {
                    //wo.WODate = DateTime.Now;
                    var wkord = await _workOrderRepository.SingleOrDefaultAsync(x => x.Id == wo.Id);
                    if(wkord == null)
                    {
                        return workOrdersVM;
                    }
                    wkord.CalcWOQty = wo.CalcWOQty;
                    wkord.PlanCompletionDate = wo.PlanCompletionDate;
                    wkord.BuildToStock = wo.BuildToStock;
                    wkord.Parentlevel = wo.Parentlevel;
                    wkord.Status = wo.Status;
                    wkord.RoutingId = wo.RoutingId;
                    wkord.StartingOpNo = wo.StartingOpNo;
                    wkord.EndingOpNo = wo.EndingOpNo;
                    wo = await _workOrderRepository.UpdateAsync(wo.Id, wkord);
                }
                try
                {
                    await _unitOfWork.CommitAsync();
                }
                catch (Exception ex)
                {
                    Exception exa = ex.InnerException;
                    string msg = ex.Message;
                }
                workOrdersVM.WOID = wo.Id;
                return workOrdersVM;
            }

            return workOrdersVM;
        }

        public async Task<List<WorkOrdersVM>> MultipleWorkOrder(List<WorkOrdersVM> workOrdersVM)
        {
            foreach (WorkOrdersVM item in workOrdersVM)
            {
                var wo = _mapper.Map<WorkOrders>(item);
                if (wo.SalesOrderId > 0)
                {
                    if (wo.Id == 0)
                    {
                        wo.WODate = DateTime.Now;
                        wo.WONumber = "WO_" + wo.WODate.Value.ToString("yyyyMMddHHmmssffff");
                        wo.Status = 1;
                        try
                        {
                            await _workOrderRepository.AddAsync(wo);
                        }
                        catch (Exception ex)
                        {
                            Exception exa = ex.InnerException;
                            string msg = ex.Message;
                        }
                    }
                    //else
                    //{
                    //    wo = await _workOrderRepository.UpdateAsync(wo.Id, wo);
                    //}
                    try
                    {
                        await _unitOfWork.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        Exception exa = ex.InnerException;
                        string msg = ex.Message;
                    }
                }
                item.WOID = wo.Id;
                item.WONumber = wo.WONumber;

            }
            return workOrdersVM;
        }

        public async Task<List<WOSOVM>> PostWOSO(List<WOSOVM> woso)
        {
            foreach (WOSOVM item in woso)
            {
                var wosorel = _mapper.Map<WOSO>(item);
                if (wosorel.SalesOrderId > 0)
                {
                    if (wosorel.Id == 0)
                    {
                        try
                        {
                            await _wosoRepository.AddAsync(wosorel);
                        }
                        catch (Exception ex)
                        {
                            Exception exa = ex.InnerException;
                            string msg = ex.Message;
                        }
                        try
                        {
                            await _unitOfWork.CommitAsync();
                        }
                        catch (Exception ex)
                        {
                            Exception exa = ex.InnerException;
                            string msg = ex.Message;
                        }
                    }
                }
            }
            return woso;
        }

        public async Task<IEnumerable<WorkOrdersVM>> AllWorkOrders(long tenantId)
        {
            var allwo = _workOrderRepository.GetRangeAsync(d => d.TenantId == tenantId);
            return _mapper.Map<IEnumerable<WorkOrdersVM>>(allwo);
        }

        public async Task<WorkOrdersVM> GetSingleWO(long Id, long tenantId)
        {
            var singlewo =await _workOrderRepository.SingleOrDefaultAsync(d=>d.Id == Id);
            if (singlewo != null)
            {
              return _mapper.Map<WorkOrdersVM>(singlewo);
            }
            return new WorkOrdersVM { WOID = -1 };
        }

        public async Task<IEnumerable<WOSOVM>> GetSoWo(long workOrderId)
        {
            var so = _wosoRepository.GetRangeAsync(s => s.WorkOrderId == workOrderId).OrderBy(s => s.Id);
            try
            {
                return _mapper.Map<IEnumerable<WOSOVM>>(so);
            }
            catch (Exception ex)
            {
                return new List<WOSOVM>();                
            }
        }
    }
}
