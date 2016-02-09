using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystemDatabase.BaseClasses
{
    public interface IDomainRestricted
    {
        int DomainId { get; set; }
    }
}
