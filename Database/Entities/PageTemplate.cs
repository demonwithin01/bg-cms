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
    [Table( "PageTemplate" )]
    public class PageTemplate : EntityBase, IDomainRestricted
    {
        [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int PageTemplateId { get; set; }

        public int DomainId { get; set; }

        public string Name { get; set; }

        public string ModelName { get; set; }
    }
}
