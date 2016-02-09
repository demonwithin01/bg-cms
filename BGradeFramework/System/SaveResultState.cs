using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework
{
    public enum SaveResultState
    {
        Success = 1,
        Fail = 2,
        IncorrectDomain = 3,
        AccessDenied = 4,
        WritePermissionsFailed = 5
    }
}
