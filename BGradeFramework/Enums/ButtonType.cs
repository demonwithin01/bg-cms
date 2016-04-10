using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework
{
    public enum ButtonType
    {
        [Display( Name = "primary" )]
        Primary = 1,

        [Display( Name = "secondary" )]
        Secondary = 2,

        [Display( Name = "tertiary" )]
        Tertiary = 3,

        [Display( Name = "cancel" )]
        Cancel = 4
    }
}
