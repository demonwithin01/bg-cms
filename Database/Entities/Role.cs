using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystemDatabase
{
    [Table( "[webpages_Roles]" )]
    public partial class Role
    {
        [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int RoleId { get; set; }

        public string RoleName { get; set; }
    }
}
