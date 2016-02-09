using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystemDatabase
{
    public class ContentManagementDb : DbContext
    {

        public ContentManagementDb()
            : base ( "ContentManagementSystem" ) { }

        /** Users **/
        public DbSet<UserProfile> Users { get; set; }

        /** Domains **/
        public DbSet<Domain> Domains { get; set; }
        public DbSet<DomainNavigationItem> DomainNavigationItems { get; set; }

        /** Content **/
        public DbSet<Content> Content { get; set; }
        public DbSet<BlogPost> Blogs { get; set; }
        public DbSet<Page> Pages { get; set; }

        public DbSet<Upload> Uploads { get; set; }


        /** Products **/
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
