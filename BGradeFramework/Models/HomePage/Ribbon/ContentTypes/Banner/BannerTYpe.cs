using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework.Models.HomePage.ContentTypes
{
    public enum BannerType
    {
        [Display( Name = "Carousel" )]
        Carousel = 1,

        [Display( Name = "Fade over" )]
        FadeOver = 2
    }
}
