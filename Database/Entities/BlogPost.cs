using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ContentManagementSystemDatabase.BaseClasses;
using System.Collections.Generic;

namespace ContentManagementSystemDatabase
{
    [Table( "Blog" )]
    public class BlogPost : UTCEntityBase, IDomainRestricted
    {
        [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int BlogId { get; set; }

        public int DomainId { get; set; }
        
        [ForeignKey( "CreatedByUser" )]
        public int CreatedByUserId { get; set; }
        public virtual UserProfile CreatedByUser { get; set; }

        public virtual ICollection<BlogPostContent> BlogPostContent { get; set; }
    }
}
