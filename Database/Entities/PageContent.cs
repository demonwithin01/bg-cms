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
    [Table( "[PageContent]" )]
    public class PageContent : UTCDateUpdatedBase
    {
        [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int PageContentId { get; set; }

        [ForeignKey( "Page" )]
        public int PageId { get; set; }
        public virtual Page Page { get; set; }

        [MaxLength( 150 )]
        public string Title { get; set; }

        public string Content { get; set; }

        [ForeignKey( "LastEditedByUser" )]
        public int LastEditedByUserId { get; set; }
        public virtual UserProfile LastEditedByUser { get; set; }

        public PublishStatus PublishStatus { get; set; }
    }
}
