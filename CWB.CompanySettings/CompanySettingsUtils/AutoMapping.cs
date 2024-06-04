using AutoMapper;
using CWB.CompanySettings.Domain;
using CWB.CompanySettings.ViewModels.Designations;
using CWB.CompanySettings.ViewModels.DocType;
using CWB.CompanySettings.ViewModels.Location;
using CWB.BusinessProcesses.Domain;
using CWB.BusinessProcesses.ViewModels;

namespace CWB.CompanySettings.CompanySettingsUtils
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<DocumentTypeVM, DocumentType>()
                .ForMember(m => m.Id, m => m.MapFrom(src => src.DocumentTypeId))
                .ForMember(m => m.Name, m => m.MapFrom(src => src.Name))
                .ForMember(m => m.Description, m => m.MapFrom(src => src.Description)) 
                .ForMember(m => m.Extension, m => m.MapFrom(src => src.Extension))
                .ForMember(m => m.IsUploadedByUser, m => m.MapFrom(src => src.IsUploadedByUser));
            CreateMap<Domain.DocumentType, DocumentTypeVM>()
                 .ForMember(m => m.DocumentTypeId, m => m.MapFrom(src => src.Id))
                .ForMember(m => m.Name, m => m.MapFrom(src => src.Name))
                .ForMember(m => m.Description, m => m.MapFrom(src => src.Description))
                .ForMember(m => m.Extension, m => m.MapFrom(src => src.Extension))
                .ForMember(m => m.IsUploadedByUser, m => m.MapFrom(src => src.IsUploadedByUser));

            CreateMap<PlantVM, Plant>()
                .ForMember(m => m.Id, m => m.MapFrom(src => src.PlantId))
                .ForMember(m => m.Name, m => m.MapFrom(src => src.Name))
                .ForMember(m => m.Address, m => m.MapFrom(src => src.Address))
                .ForMember(m => m.Notes, m => m.MapFrom(src => src.Notes))
                .ForMember(m => m.IsMainPlant, m => m.MapFrom(src => src.IsMainPlant))
                .ForMember(m => m.IsProductDesigned, m => m.MapFrom(src => src.IsProductDesigned));
            CreateMap<Plant, PlantVM>()
                 .ForMember(m => m.PlantId, m => m.MapFrom(src => src.Id))
                .ForMember(m => m.Name, m => m.MapFrom(src => src.Name))
                .ForMember(m => m.Address, m => m.MapFrom(src => src.Address))
                .ForMember(m => m.Notes, m => m.MapFrom(src => src.Notes))
                .ForMember(m => m.IsMainPlant, m => m.MapFrom(src => src.IsMainPlant))
                .ForMember(m => m.IsProductDesigned, m => m.MapFrom(src => src.IsProductDesigned));

      


            //Designation
            CreateMap<DesignationVM, Designation>()
                .ForMember(m => m.Id, m => m.MapFrom(src => src.DesignationId))
                .ForMember(m => m.Name, m => m.MapFrom(src => src.Name))
                .ForMember(m => m.TenantId, m => m.MapFrom(src => src.TenantId));
            CreateMap<Domain.Designation, DesignationVM>()
             .ForMember(m => m.DesignationId, m => m.MapFrom(src => src.Id))
             .ForMember(m => m.Name, m => m.MapFrom(src => src.Name))
             .ForMember(m => m.TenantId, m => m.MapFrom(src => src.TenantId));
            CreateMap<Designation, DesignationListVM>()
                .ForMember(m => m.DesignationId, m => m.MapFrom(src => src.Id));

            CreateMap<ShopDepartment, ShopDepartmentVM>()
                .ForMember(m => m.DepartmentId, m => m.MapFrom(src => src.Id))
                .ForMember(m => m.PlantId, m => m.MapFrom(src => src.PlantId))
                .ForMember(m => m.Name, m => m.MapFrom(src => src.Name))
                .ForMember(m => m.NoOfShifts, m => m.MapFrom(src => src.NoOfShifts))
                .ForMember(m => m.Activity, m => m.MapFrom(src => src.Activity))
                .ForMember(m => m.PlantName, m => m.MapFrom(src => src.Plant.Name))
                .ForMember(m => m.Section, m => m.MapFrom(src => src.Section))
                .ForMember(m => m.ProdDept, m => m.MapFrom(src => src.ProdDept));
            CreateMap<ShopDepartmentVM, ShopDepartment>()
                .ForMember(m => m.Id, m => m.MapFrom(src => src.DepartmentId))
                .ForMember(m => m.PlantId, m => m.MapFrom(src => src.PlantId))
                .ForMember(m => m.Name, m => m.MapFrom(src => src.Name))
                .ForMember(m => m.NoOfShifts, m => m.MapFrom(src => src.NoOfShifts))
                .ForMember(m => m.Activity, m => m.MapFrom(src => src.Activity))
                .ForMember(m => m.Section, m => m.MapFrom(src => src.Section))
                .ForMember(m => m.ProdDept, m => m.MapFrom(src => src.ProdDept));

            //BusingAquisition
            CreateMap<OrderStatus, OrderStatusVM>()
                .ForMember(m => m.StatusId, m => m.MapFrom(src => src.Id))
                .ForMember(m => m.StatusId, m => m.MapFrom(src => src.StatusId))
               .ForMember(m => m.Status, m => m.MapFrom(src => src.Status));

            CreateMap<OrderStatusVM, OrderStatus>()
                .ForMember(m => m.Id, m => m.MapFrom(src => src.StatusId))
                .ForMember(m => m.StatusId, m => m.MapFrom(src => src.StatusId))
               .ForMember(m => m.Status, m => m.MapFrom(src => src.Status));

            CreateMap<SalesOrder, DeliveryScheduleVM>()
               .ForMember(m => m.ScheduleId, m => m.MapFrom(src => src.Id))
               .ForMember(m => m.RequiredQuantity, m => m.MapFrom(src => src.RequiredQuantity))
               .ForMember(m => m.CustomerOrderId, m => m.MapFrom(src => src.CustomerOrderId))
               .ForMember(m => m.RequiredByDate, m => m.MapFrom(src => src.RequiredByDate))
               .ForMember(m => m.DSPartId, m => m.MapFrom(src => src.PartId))
               .ForMember(m => m.Comment, m => m.MapFrom(src => src.Comment));
            CreateMap<DeliveryScheduleVM, SalesOrder>()
                .ForMember(m => m.Id, m => m.MapFrom(src => src.ScheduleId))
               .ForMember(m => m.RequiredQuantity, m => m.MapFrom(src => src.RequiredQuantity))
               .ForMember(m => m.CustomerOrderId, m => m.MapFrom(src => src.CustomerOrderId))
               .ForMember(m => m.RequiredByDate, m => m.MapFrom(src => src.RequiredByDate))
               .ForMember(m => m.PartId, m => m.MapFrom(src => src.DSPartId))
               .ForMember(m => m.Comment, m => m.MapFrom(src => src.Comment));
            
            CreateMap<SalesOrder, DeliverySchedule>()
               .ForMember(m => m.RequiredQuantity, m => m.MapFrom(src => src.RequiredQuantity))
               .ForMember(m => m.CustomerOrderId, m => m.MapFrom(src => src.CustomerOrderId))
               .ForMember(m => m.RequiredByDate, m => m.MapFrom(src => src.RequiredByDate))
               .ForMember(m => m.PartId, m => m.MapFrom(src => src.PartId))
               .ForMember(m => m.Comment, m => m.MapFrom(src => src.Comment));
            CreateMap<DeliverySchedule, SalesOrder>()
               .ForMember(m => m.RequiredQuantity, m => m.MapFrom(src => src.RequiredQuantity))
               .ForMember(m => m.CustomerOrderId, m => m.MapFrom(src => src.CustomerOrderId))
               .ForMember(m => m.RequiredByDate, m => m.MapFrom(src => src.RequiredByDate))
               .ForMember(m => m.PartId, m => m.MapFrom(src => src.PartId))
               .ForMember(m => m.Comment, m => m.MapFrom(src => src.Comment));

            /**CreateMap<DeliverySchedule, DeliveryScheduleVM>()
               .ForMember(m => m.ScheduleId, m => m.MapFrom(src => src.Id))
               .ForMember(m => m.RequiredQuantity, m => m.MapFrom(src => src.RequiredQuantity))
               .ForMember(m => m.CustomerOrderId, m => m.MapFrom(src => src.CustomerOrderId))
               .ForMember(m => m.RequiredByDate, m => m.MapFrom(src => src.RequiredByDate))
               .ForMember(m => m.DSPartId, m => m.MapFrom(src => src.PartId))
               .ForMember(m => m.Comment, m => m.MapFrom(src => src.Comment));
            CreateMap<DeliveryScheduleVM, DeliverySchedule>()
               .ForMember(m => m.Id, m => m.MapFrom(src => src.ScheduleId))
               .ForMember(m => m.RequiredQuantity, m => m.MapFrom(src => src.RequiredQuantity))
               .ForMember(m => m.CustomerOrderId, m => m.MapFrom(src => src.CustomerOrderId))
               .ForMember(m => m.RequiredByDate, m => m.MapFrom(src => src.RequiredByDate))
               .ForMember(m => m.PartId, m => m.MapFrom(src => src.DSPartId))
               .ForMember(m => m.Comment, m => m.MapFrom(src => src.Comment));*/


            CreateMap<SOAggregate, SOAggregateVM>()
               .ForMember(m => m.SOAggregateId, m => m.MapFrom(src => src.Id))
               .ForMember(m => m.CustomerOrderId, m => m.MapFrom(src => src.CustomerOrderId))
               .ForMember(m => m.PartId, m => m.MapFrom(src => src.PartId))
               .ForMember(m => m.Comment, m => m.MapFrom(src => src.Comment));
            CreateMap<SOAggregateVM, SOAggregate>()
                .ForMember(m => m.Id, m => m.MapFrom(src => src.SOAggregateId))
               .ForMember(m => m.CustomerOrderId, m => m.MapFrom(src => src.CustomerOrderId))
               .ForMember(m => m.PartId, m => m.MapFrom(src => src.PartId))
               .ForMember(m => m.Comment, m => m.MapFrom(src => src.Comment));

            CreateMap<POLog, POLogVM>()
                .ForMember(m => m.POLogId, m => m.MapFrom(src => src.Id))
                .ForMember(m => m.PODate, m => m.MapFrom(src => src.CreationDate))
                .ForMember(m => m.CustomerOrderId, m => m.MapFrom(src => src.CustomerOrderId))
                .ForMember(m => m.SalesOrderId, m => m.MapFrom(src => src.SalesOrderId))
                .ForMember(m => m.PartId, m => m.MapFrom(src => src.PartId))
                .ForMember(m => m.User, m => m.MapFrom(src => src.User))
                .ForMember(m => m.NewValue, m => m.MapFrom(src => src.NewValue))
                .ForMember(m => m.OldValue, m => m.MapFrom(src => src.OldValue))
                .ForMember(m => m.Comment, m => m.MapFrom(src => src.Comment))
                .ForMember(m => m.Event, m => m.MapFrom(src => src.Event));
            CreateMap<POLogVM, POLog>()
                .ForMember(m => m.Id, m => m.MapFrom(src => src.POLogId))
                .ForMember(m => m.CustomerOrderId, m => m.MapFrom(src => src.CustomerOrderId))
                .ForMember(m => m.SalesOrderId, m => m.MapFrom(src => src.SalesOrderId))
                .ForMember(m => m.PartId, m => m.MapFrom(src => src.PartId))
                .ForMember(m => m.User, m => m.MapFrom(src => src.User))
                .ForMember(m => m.NewValue, m => m.MapFrom(src => src.NewValue))
                .ForMember(m => m.OldValue, m => m.MapFrom(src => src.OldValue))
                .ForMember(m => m.Comment, m => m.MapFrom(src => src.Comment))
                .ForMember(m => m.Event, m => m.MapFrom(src => src.Event));

            CreateMap<CustomerOrder, CustomerOrderVM>()
               .ForMember(m => m.CustomerOrderId, m => m.MapFrom(src => src.Id))
               .ForMember(m => m.CustomerId, m => m.MapFrom(src => src.CustomerId))
               .ForMember(m => m.CustomerName, m => m.MapFrom(src => src.CustomerName))
               .ForMember(m => m.OrderType, m => m.MapFrom(src => src.OrderType))
               .ForMember(m => m.PONumber, m => m.MapFrom(src => src.PONumber))
               .ForMember(m => m.PODate, m => m.MapFrom(src => src.PODate))
               .ForMember(m => m.DirectEntryDetails, m => m.MapFrom(src => src.DirectEntryDetails))
               .ForMember(m => m.Comment, m => m.MapFrom(src => src.Comment))
               .ForMember(m => m.LineNo, m => m.MapFrom(src => src.LineNo))
               .ForMember(m => m.Status, m => m.MapFrom(src => src.Status))
               .ForMember(m => m.Plan, m => m.MapFrom(src => src.Plan))
               .ForMember(m => m.Matl, m => m.MapFrom(src => src.Matl))
               .ForMember(m => m.Hold, m => m.MapFrom(src => src.Hold))
               .ForMember(m => m.Done, m => m.MapFrom(src => src.Done))
               .ForMember(m => m.WIP, m => m.MapFrom(src => src.WIP));

            CreateMap<CustomerOrderVM, CustomerOrder>()
              .ForMember(m => m.Id, m => m.MapFrom(src => src.CustomerOrderId))
              .ForMember(m => m.CustomerId, m => m.MapFrom(src => src.CustomerId))
              .ForMember(m => m.CustomerName, m => m.MapFrom(src => src.CustomerName))
              .ForMember(m => m.PONumber, m => m.MapFrom(src => src.PONumber))
              .ForMember(m => m.PODate, m => m.MapFrom(src => src.PODate))
              .ForMember(m => m.DirectEntryDetails, m => m.MapFrom(src => src.DirectEntryDetails))
              .ForMember(m => m.Comment, m => m.MapFrom(src => src.Comment))
              .ForMember(m => m.LineNo, m => m.MapFrom(src => src.LineNo))
              .ForMember(m => m.Status, m => m.MapFrom(src => src.Status))
              .ForMember(m => m.Plan, m => m.MapFrom(src => src.Plan))
              .ForMember(m => m.Matl, m => m.MapFrom(src => src.Matl))
              .ForMember(m => m.Hold, m => m.MapFrom(src => src.Hold))
              .ForMember(m => m.Done, m => m.MapFrom(src => src.Done))
              .ForMember(m => m.WIP, m => m.MapFrom(src => src.WIP));


            CreateMap<SalesOrder, SalesOrderVM>()
                .ForMember(m => m.SalesOrderId, m => m.MapFrom(src => src.Id))
                .ForMember(m => m.CustomerOrderId, m => m.MapFrom(src => src.CustomerOrderId))
                .ForMember(m => m.WorkOrderId, m => m.MapFrom(src => src.WorkOrderId))
                .ForMember(m => m.PartId, m => m.MapFrom(src => src.PartId))
                .ForMember(m => m.SONumber, m => m.MapFrom(src => src.SONumber))
                .ForMember(m => m.WorkOrderNo, m => m.MapFrom(src => src.WorkOrderNo))
                .ForMember(m => m.SODate, m => m.MapFrom(src => src.SODate))
                .ForMember(m => m.Comment, m => m.MapFrom(src => src.Comment))
                .ForMember(m => m.Status, m => m.MapFrom(src => src.Status))
                //.ForMember(m => m.ScheduleId, m => m.MapFrom(src => src.ScheduleId))
                .ForMember(m => m.Plan, m => m.MapFrom(src => src.Plan))
                .ForMember(m => m.Matl, m => m.MapFrom(src => src.Matl))
                .ForMember(m => m.Hold, m => m.MapFrom(src => src.Hold))
                .ForMember(m => m.Done, m => m.MapFrom(src => src.Done))
                .ForMember(m => m.WIP, m => m.MapFrom(src => src.WIP))
                .ForMember(m => m.RequiredQuantity, m => m.MapFrom(src => src.RequiredQuantity))
                .ForMember(m => m.RequiredByDate, m => m.MapFrom(src => src.RequiredByDate));

            CreateMap<SalesOrderVM, SalesOrder>()
               .ForMember(m => m.Id, m => m.MapFrom(src => src.SalesOrderId))
               .ForMember(m => m.CustomerOrderId, m => m.MapFrom(src => src.CustomerOrderId))
               .ForMember(m => m.WorkOrderId, m => m.MapFrom(src => src.WorkOrderId))
               .ForMember(m => m.PartId, m => m.MapFrom(src => src.PartId))
               .ForMember(m => m.SONumber, m => m.MapFrom(src => src.SONumber))
               .ForMember(m => m.WorkOrderNo, m => m.MapFrom(src => src.WorkOrderNo))
               .ForMember(m => m.Comment, m => m.MapFrom(src => src.Comment))
               .ForMember(m => m.SODate, m => m.MapFrom(src => src.SODate))
               .ForMember(m => m.Status, m => m.MapFrom(src => src.Status))
               //.ForMember(m => m.ScheduleId, m => m.MapFrom(src => src.ScheduleId))
               .ForMember(m => m.Plan, m => m.MapFrom(src => src.Plan))
               .ForMember(m => m.Matl, m => m.MapFrom(src => src.Matl))
               .ForMember(m => m.Hold, m => m.MapFrom(src => src.Hold))
               .ForMember(m => m.Done, m => m.MapFrom(src => src.Done))
               .ForMember(m => m.WIP, m => m.MapFrom(src => src.WIP))
               .ForMember(m => m.RequiredQuantity, m => m.MapFrom(src => src.RequiredQuantity))
               .ForMember(m => m.RequiredByDate, m => m.MapFrom(src => src.RequiredByDate));


            CreateMap<HolidayVM, Holiday>()
               .ForMember(m => m.Id, m => m.MapFrom(src => src.HolidayId))
              .ForMember(m => m.PlantId, m => m.MapFrom(src => src.PlantId))
              .ForMember(m => m.Name, m => m.MapFrom(src => src.Name))
              .ForMember(m => m.HolidayDate, m => m.MapFrom(src => src.HolidayDate));

            CreateMap<PlantWorkingDetailsVM,PlantWorkingDetails>()
                .ForMember(m => m.Id, m => m.MapFrom(src => src.WDId))
               .ForMember(m => m.PlantId, m => m.MapFrom(src => src.PlantId))
               .ForMember(m => m.WeeklyOff1, m => m.MapFrom(src => src.WeeklyOff1))
               .ForMember(m => m.WeeklyOff2, m => m.MapFrom(src => src.WeeklyOff2))
               .ForMember(m => m.NoOfShifts, m => m.MapFrom(src => src.NoOfShifts))
               .ForMember(m => m.FirstShiftStartTime, m => m.MapFrom(src => src.FirstShiftStartTime))
               .ForMember(m => m.SecondShiftStartTime, m => m.MapFrom(src => src.SecondShiftStartTime))
               .ForMember(m => m.ThirdShiftStartTime, m => m.MapFrom(src => src.ThirdShiftStartTime))
               .ForMember(m => m.FirstShiftDuration, m => m.MapFrom(src => src.FirstShiftDuration))
               .ForMember(m => m.SecondShiftDuration, m => m.MapFrom(src => src.SecondShiftDuration))
               .ForMember(m => m.ThirdShiftDuration, m => m.MapFrom(src => src.ThirdShiftDuration));

            CreateMap<Holiday, HolidayVM>()
                .ForMember(m => m.HolidayId, m => m.MapFrom(src => src.Id))
               .ForMember(m => m.PlantId, m => m.MapFrom(src => src.PlantId))
               .ForMember(m => m.Name, m => m.MapFrom(src => src.Name))
               .ForMember(m => m.HolidayDate, m => m.MapFrom(src => src.HolidayDate));

            CreateMap<PlantWorkingDetails,PlantWorkingDetailsVM>()
                .ForMember(m => m.WDId, m => m.MapFrom(src => src.Id))
               .ForMember(m => m.PlantId, m => m.MapFrom(src => src.PlantId))
               .ForMember(m => m.WeeklyOff1, m => m.MapFrom(src => src.WeeklyOff1))
               .ForMember(m => m.WeeklyOff2, m => m.MapFrom(src => src.WeeklyOff2))
               .ForMember(m => m.NoOfShifts, m => m.MapFrom(src => src.NoOfShifts))
               .ForMember(m => m.FirstShiftStartTime, m => m.MapFrom(src => src.FirstShiftStartTime))
               .ForMember(m => m.SecondShiftStartTime, m => m.MapFrom(src => src.SecondShiftStartTime))
               .ForMember(m => m.ThirdShiftStartTime, m => m.MapFrom(src => src.ThirdShiftStartTime))
               .ForMember(m => m.FirstShiftDuration, m => m.MapFrom(src => src.FirstShiftDuration))
               .ForMember(m => m.SecondShiftDuration, m => m.MapFrom(src => src.SecondShiftDuration))
               .ForMember(m => m.ThirdShiftDuration, m => m.MapFrom(src => src.ThirdShiftDuration));

            CreateMap<PlantWorkingDetails, PlantVM>()
          .ForMember(m => m.WDId, m => m.MapFrom(src => src.Id))
          .ForMember(m => m.PlantId, m => m.MapFrom(src => src.Plant.Id))
          .ForMember(m => m.Name, m => m.MapFrom(src => src.Plant.Name))
          .ForMember(m => m.IsMainPlant, m => m.MapFrom(src => src.Plant.IsMainPlant))
          .ForMember(m => m.IsProductDesigned, m => m.MapFrom(src => src.Plant.IsProductDesigned))
          .ForMember(m => m.Address, m => m.MapFrom(src => src.Plant.Address))
          .ForMember(m => m.Notes, m => m.MapFrom(src => src.Plant.Notes))
          .ForMember(m => m.WeeklyOff1, m => m.MapFrom(src => src.WeeklyOff1))
          .ForMember(m => m.NoOfShifts, m => m.MapFrom(src => src.NoOfShifts))
          .ForMember(m => m.FirstShiftStartTime, m => m.MapFrom(src => src.FirstShiftStartTime));

            CreateMap<PlantVM, PlantWorkingDetails>()
                 .ForMember(m => m.Id, m => m.MapFrom(src => src.WDId))
                 .ForMember(m=>m.PlantId,m=>m.MapFrom(src=>src.PlantId))
                 .ForMember(m => m.NoOfShifts, m => m.MapFrom(src => src.NoOfShifts))
                 .ForMember(m => m.WeeklyOff1, m => m.MapFrom(src => src.WeeklyOff1))
                 .ForMember(m => m.FirstShiftStartTime, m => m.MapFrom(src => src.FirstShiftStartTime));
        }
    }
}
