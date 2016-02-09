using ContentManagementSystemDatabase.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystemDatabase
{
    [Table( "[BlogContent]" )]
    public class BlogContent : UTCDateUpdatedBase
    {
        [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int BlogContentId { get; set; }

        [ForeignKey( "Blog" )]
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }

        [MaxLength( 150 )]
        public string Title { get; set; }

        public string Content { get; set; }

        [ForeignKey( "LastEditedByUser" )]
        public int LastEditedByUserId { get; set; }
        public virtual UserProfile LastEditedByUser { get; set; }

        public PublishStatus PublishStatus { get; set; }
    }
}
