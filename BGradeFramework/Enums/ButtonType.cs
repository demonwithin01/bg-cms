using System.ComponentModel.DataAnnotations;

namespace ContentManagementSystem.Framework
{
    /// <summary>
    /// The button types for rendering out buttons using the Html helper.
    /// </summary>
    public enum ButtonType
    {
        /// <summary>
        /// A primary button.
        /// </summary>
        [Display( Name = "primary" )]
        Primary = 1,

        /// <summary>
        /// A secondary button.
        /// </summary>
        [Display( Name = "secondary" )]
        Secondary = 2,

        /// <summary>
        /// A tertiary button.
        /// </summary>
        [Display( Name = "tertiary" )]
        Tertiary = 3,

        /// <summary>
        /// A cancel/delete button.
        /// </summary>
        [Display( Name = "cancel" )]
        Cancel = 4
    }
}
