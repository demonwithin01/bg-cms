using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ContentManagementSystemDatabase.BaseClasses;

namespace ContentManagementSystemDatabase
{
    [Table( "[Page]" )]
    public class Page : EntityBase, IDomainRestricted
    {
        [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity ), AutoMapIgnore]
        public int PageId { get; set; }

        public int DomainId { get; set; }

        [NotMapped]
        public string PageSlug { get; set; }

        [ForeignKey( "CreatedByUser" )]
        public int CreatedByUserId { get; set; }
        public virtual UserProfile CreatedByUser { get; set; }

        public bool RequiresLogin { get; set; }
        
        public virtual ICollection<PageContent> PageContent { get; set; }
    }
}
