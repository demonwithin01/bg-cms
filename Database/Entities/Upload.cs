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
    [Table( "[Upload]" )]
    public class Upload : EntityBase, IDomainRestricted
    {
        [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int UploadId { get; set; }

        public int DomainId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Filename { get; set; }

        public string PhysicalLocation { get; set; }
    }
}
