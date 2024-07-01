using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.ProductionPlanWO.Utils
{
    public class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class WO
        {
            public const string PostWorkOrder = Base + "/workorder";
            public const string PostMultipleWorkOrder = Base + "/multipleworkorder";
            public const string HelloWorld = Base + "/helloworld";
            public const string AllWorkOrders = Base + "/allworkorders/{tenantId}";
            public const string GetSingleWorkOrder = Base + "/getsingleworkorder/{Id}/{tenantId}";
            public const string GetSoWo = Base + "/getsowo/{workOrderId}";
            public const string PostWOSORel = Base + "/wosorel";
        }
    }
}
