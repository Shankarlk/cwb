﻿using CWB.CommonUtils.Common.Repositories;
using CWB.Masters.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.Masters.Repositories.ItemMaster
{
    public class PartStatusChangeLogRepository : Repository<Domain.ItemMaster.PartStatusChangeLog>, IPartStatusChangeLogRepository
    {
        public PartStatusChangeLogRepository(MastersDbContext context)
        : base(context)
        {
        }
    }
}
