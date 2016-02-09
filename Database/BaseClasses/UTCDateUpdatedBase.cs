using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystemDatabase.BaseClasses
{
    public class UTCDateUpdatedBase
    {
        public virtual void Initialize()
        {
            UTCDateUpdated = DateTime.UtcNow;
        }

        public virtual void UpdateTimeStamp()
        {
            UTCDateUpdated = DateTime.UtcNow;
        }

        public DateTime UTCDateUpdated { get; set; }
    }
}
