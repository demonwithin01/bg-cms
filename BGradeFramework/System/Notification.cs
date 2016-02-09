using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework
{

    public enum NotificationType
    {

        [Display( Name = "confirmation" )]
        Confirmation,

        [Display( Name = "confirmation" )]
        Message,

        [Display( Name = "confirmation" )]
        Error

    }

}
