using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystemDatabase
{
    [Table( "UserProfile" )]
    public partial class UserProfile
    {
        [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int UserId { get; set; }

        [ForeignKey( "Domain" )]
        public int DomainId { get; set; }
        public virtual Domain Domain { get; set; }

        [ForeignKey( "Role" )]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public string UserName { get; set; }
    }
}
