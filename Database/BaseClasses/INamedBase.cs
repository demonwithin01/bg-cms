using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystemDatabase.BaseClasses
{
    public interface INamedBase
    {
        string Name { get; set; }
    }
}
