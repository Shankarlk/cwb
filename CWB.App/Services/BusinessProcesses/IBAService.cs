using CWB.App.Models.BusinessProcesses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CWB.App.Services.BusinessProcesses
{
   
    public interface IBAService
    {

        Task<bool> RemoveSalesOrder(long salesOrderId);
        Task<bool> RemoveCustomerOder(long customerOrderId);
        Task<bool> RemoveDeliverySchedule(long scheduleId);
        //Task<IEnumerable<POLogVM>> RemoveSalesOrder(long tenantId, long salesOrderId);

        Task<IEnumerable<POLogVM>> GetPOLogs(long customerOrderId);
        Task<IEnumerable<SalesOrderVM>> GetSalesOrders(long customerOrderId);
        Task<IEnumerable<CustomerOrderRowVM>> GetCustomerOrders();
        Task<IEnumerable<DeliveryScheduleVM>> GetSchedules(long customerOrderId);

        Task<bool> AddSalesOrders(long customerOrderId);

        Task<SalesOrderVM> PostSalesOrder(SalesOrderVM salesOrderVM);
        Task<POLogVM> PostSOLog(POLogVM poLogVM);
        Task<POLogVM> PostPOLog(POLogVM poLogVM);
        
        Task<CustomerOrderVM> PostCustomerOrder(CustomerOrderVM customerOrderVM);
        Task<DeliveryScheduleVM> PostDeliverySchedule(DeliveryScheduleVM deliveryScheduleVM);
        Task<SOAggregateVM> PostSOAggregate(SOAggregateVM sOAggregateVM);
        Task<SOAggregateVM> GetSOAggregate(long customerOrderId);

        //Task<DeliveryScheduleVM> PostOrderStatus();


        Task<string> HelloWorld();
    }
}
