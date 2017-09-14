using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework.Models.HomePage
{
    public enum ContentType
    {
        [Display( Name = "Editable Content" )]
        EditableContent = 0,

        Banner = 1
    }
}
