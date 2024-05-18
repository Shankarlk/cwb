﻿using CWB.BusinessProcesses.Domain;
using CWB.BusinessProcesses.Infrastructure;
using CWB.CommonUtils.Common.Repositories;
using CWB.CompanySettings.Infrastructure;


namespace CWB.CompanySettings.Repositories.BusinessAquisition
{
    public class CustomerOderRepository : Repository<CustomerOrder>, ICustomerOrderRepository
    {
        public CustomerOderRepository(CompanySettingsDbContext context)
         : base(context)
        { }
    }
}