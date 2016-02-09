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
    [Table( "ProductTag" )]
    public class ProductTag : EntityBase, IDomainRestricted
    {
        [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int ProductTagId { get; set; }

        public int DomainId { get; set; }
        
        [ForeignKey( "Product" )]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string Name { get; set; }
    }
}
