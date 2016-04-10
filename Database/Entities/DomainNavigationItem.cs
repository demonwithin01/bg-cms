using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystemDatabase.BaseClasses;

namespace ContentManagementSystemDatabase
{
    [Table( "DomainNavigationItem" )]
    public class DomainNavigationItem : EntityBase, IDomainRestricted
    {
        [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity ), AutoMapIgnore]
        public int DomainNavigationItemId { get; set; }

        public int DomainId { get; set; }

        [ForeignKey( "Page" )]
        public int PageId { get; set; }
        public virtual Page Page { get; set; }

        public string Title { get; set; }

        public int Ordinal { get; set; }
    }
}
