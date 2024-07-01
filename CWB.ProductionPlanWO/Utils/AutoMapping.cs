using AutoMapper;
using CWB.ProductionPlanWO.Domain;
using CWB.ProductionPlanWO.ViewModels;

namespace CWB.ProductionPlanWO.Utils
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<WorkOrders, WorkOrdersVM>()
               .ForMember(m => m.WOID, m => m.MapFrom(src => src.Id))
               .ForMember(m => m.SalesOrderId, m => m.MapFrom(src => src.SalesOrderId))
               .ForMember(m => m.WONumber, m => m.MapFrom(src => src.WONumber))
               .ForMember(m => m.PartId, m => m.MapFrom(src => src.PartId))
               .ForMember(m => m.PartType, m => m.MapFrom(src => src.PartType))
               .ForMember(m => m.Parentlevel, m => m.MapFrom(src => src.Parentlevel))
               .ForMember(m => m.CalcWOQty, m => m.MapFrom(src => src.CalcWOQty))
               .ForMember(m => m.BuildToStock, m => m.MapFrom(src => src.BuildToStock))
               .ForMember(m => m.PlanCompletionDate, m => m.MapFrom(src => src.PlanCompletionDate))
               .ForMember(m => m.Status, m => m.MapFrom(src => src.Status))
               .ForMember(m => m.RoutingId, m => m.MapFrom(src => src.RoutingId))
               .ForMember(m => m.StartingOpNo, m => m.MapFrom(src => src.StartingOpNo))
               .ForMember(m => m.EndingOpNo, m => m.MapFrom(src => src.EndingOpNo))
               .ForMember(m => m.WODate, m => m.MapFrom(src => src.WODate));

            CreateMap<WorkOrdersVM, WorkOrders>()
               .ForMember(m => m.Id, m => m.MapFrom(src => src.WOID))
               .ForMember(m => m.SalesOrderId, m => m.MapFrom(src => src.SalesOrderId))
               .ForMember(m => m.WONumber, m => m.MapFrom(src => src.WONumber))
               .ForMember(m => m.PartId, m => m.MapFrom(src => src.PartId))
               .ForMember(m => m.PartType, m => m.MapFrom(src => src.PartType))
               .ForMember(m => m.Parentlevel, m => m.MapFrom(src => src.Parentlevel))
               .ForMember(m => m.CalcWOQty, m => m.MapFrom(src => src.CalcWOQty))
               .ForMember(m => m.BuildToStock, m => m.MapFrom(src => src.BuildToStock))
               .ForMember(m => m.PlanCompletionDate, m => m.MapFrom(src => src.PlanCompletionDate))
               .ForMember(m => m.Status, m => m.MapFrom(src => src.Status))
               .ForMember(m => m.WODate, m => m.MapFrom(src => src.WODate))
               .ForMember(m => m.RoutingId, m => m.MapFrom(src => src.RoutingId))
               .ForMember(m => m.StartingOpNo, m => m.MapFrom(src => src.StartingOpNo))
               .ForMember(m => m.EndingOpNo, m => m.MapFrom(src => src.EndingOpNo))
               .ForMember(m => m.WODate, m => m.MapFrom(src => src.WODate));

            CreateMap<WOSOVM, WOSO>()
               .ForMember(m => m.Id, m => m.MapFrom(src => src.WOSOId))
               .ForMember(m => m.SalesOrderId, m => m.MapFrom(src => src.SalesOrderId))
               .ForMember(m => m.WorkOrderId, m => m.MapFrom(src => src.WorkOrderId));

            CreateMap<WOSO, WOSOVM>()
               .ForMember(m => m.WOSOId, m => m.MapFrom(src => src.Id))
               .ForMember(m => m.SalesOrderId, m => m.MapFrom(src => src.SalesOrderId))
               .ForMember(m => m.WorkOrderId, m => m.MapFrom(src => src.WorkOrderId));
        }
    }
}
