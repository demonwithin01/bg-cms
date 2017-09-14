using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework
{
    /// <summary>
    /// The types of notifications available to the system.
    /// </summary>
    public enum NotificationType
    {
        /// <summary>
        /// The confirmation notification type.
        /// </summary>
        [Display( Name = "confirmation" )]
        Confirmation,

        /// <summary>
        /// The message notification type.
        /// </summary>
        [Display( Name = "message" )]
        Message,

        /// <summary>
        /// The error notification type.
        /// </summary>
        [Display( Name = "error" )]
        Error

    }

}
