using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystemDatabase
{
    [Table( "[Application]" )]
    public partial class Application
    {
        [Key]
        public int ApplicationId { get; set; }

        public string Name { get; set; }
    }
}
