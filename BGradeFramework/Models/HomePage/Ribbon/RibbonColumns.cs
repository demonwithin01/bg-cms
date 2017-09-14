using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework.Models.HomePage
{
    public enum RibbonColumns
    {
        [Display( Name = "One Column" )]
        OneColumn = 1,

        [Display( Name = "Two Columns" )]
        TwoColumns = 2,

        [Display( Name = "Three Columns" )]
        ThreeColumns = 3
    }
}
