using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ContentManagementSystemDatabase.BaseClasses;

namespace ContentManagementSystemDatabase
{
    [Table( "Content" )]
    public class Content : EntityBase, IDomainRestricted
    {

        [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int ContentId { get; set; }

        public int DomainId { get; set; }

        public string Data { get; set; }

    }
}
