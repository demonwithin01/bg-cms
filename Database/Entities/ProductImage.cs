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
    [Table( "ProductImage" )]
    public class ProductImage : EntityBase
    {
        [Key]
        public int ProductImageId { get; set; }

        [ForeignKey( "Product" )]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey( "Upload" )]
        public int UploadId { get; set; }
        public virtual Upload Upload { get; set; }

        public int Ordinal { get; set; }
    }
}
