using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework
{
    /// <summary>
    /// The types of save results available to the system.
    /// </summary>
    public enum SaveResultState
    {
        /// <summary>
        /// The succeeded save result state.
        /// </summary>
        [Display( Name = "Success" )]
        Success = 1,

        /// <summary>
        /// The failed save result state.
        /// </summary>
        [Display( Name = "Fail" )]
        Fail = 2,

        /// <summary>
        /// The incorrect domain save result state.
        /// </summary>
        [Display( Name = "Incorrect Domain" )]
        IncorrectDomain = 3,

        /// <summary>
        /// The access was denied save result state.
        /// </summary>
        [Display( Name = "Access Denied" )]
        AccessDenied = 4,

        /// <summary>
        /// The invalid write permissions save result state.
        /// </summary>
        [Display( Name = "Invalid Write Permissions" )]
        InvalidWritePermissions = 5
    }
}
