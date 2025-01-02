﻿using CWB.CommonUtils.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.CompanySettings.Domain
{
    public class Role_Ui_List : BaseEntity
    {
        public long Ui_Id { get; set; }
        public long RoleId { get; set; }
        public long PermissionId { get; set; }
        public long EmployeeId { get; set; }
        public string Comment { get; set; }
        public long TenantId { get; set; }
    }
}
