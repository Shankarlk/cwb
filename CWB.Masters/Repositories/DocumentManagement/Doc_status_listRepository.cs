using CWB.CommonUtils.Common.Repositories;
using CWB.Masters.Domain.DocumentManagement;
using CWB.Masters.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.Masters.Repositories.DocumentManagement
{
    public class Doc_status_listRepository : Repository<Doc_status_list>, IDoc_status_listRepository
    {
        public Doc_status_listRepository(MastersDbContext context)
         : base(context)
        { }
    }
}
