using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework
{
    public class EditorLocationAttribute : Attribute
    {
        public EditorLocationAttribute( string location )
        {
            Location = location;
        }

        public string Location { get; private set; }
    }
}
