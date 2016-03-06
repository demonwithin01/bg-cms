using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework
{
    public class DisplayLocationAttribute : Attribute
    {
        public DisplayLocationAttribute( string location )
        {
            Location = location;
        }

        public string Location { get; private set; }
    }
}
