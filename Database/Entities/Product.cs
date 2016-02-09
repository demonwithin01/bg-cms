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
    [Table( "Product" )]
    public class Product : EntityBase, IDomainRestricted
    {
        [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int ProductId { get; set; }

        public int DomainId { get; set; }

        [ForeignKey( "ProductCategory" )]
        public int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }

        public string ItemNo { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int StockCount { get; set; }


        public virtual ICollection<ProductImage> ProductImages { get; set; }

        public virtual ICollection<ProductTag> ProductTags { get; set; }
    }
}
