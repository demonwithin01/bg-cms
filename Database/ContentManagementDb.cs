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
        public DbSet<DomainHomePage> DomainHomePages { get; set; }
        public DbSet<DomainNavigationItem> DomainNavigationItems { get; set; }

        /** Content **/
        public DbSet<Content> Content { get; set; }
        public DbSet<BlogPost> Blogs { get; set; }
        public DbSet<BlogPostContent> BlogPostContent { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageContent> PageContent { get; set; }

        public DbSet<Upload> Uploads { get; set; }
        

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            base.OnModelCreating( modelBuilder );

            modelBuilder.Entity<DomainNavigationItem>()
                        .HasMany( s => s.SubNavigationItems )
                        .WithOptional( s => s.ParentDomainNavigationItem );

            //modelBuilder.Entity<DomainNavigationItem>()
            //            .HasOptional( s => s.ParentDomainNavigationItem )
            //            .WithMany()
            //            .HasForeignKey( s => s.ParentDomainNavigationItemId );
        }

        /// <summary>
        /// Finds the corresponding page associated with the slug provided.
        /// </summary>
        /// <param name="currentDomainId">The current user domain.</param>
        /// <param name="pageSlug">The slug that identifies the page.</param>
        /// <returns>The corresponding page if found, otherwise null.</returns>
        public Page FindPage( int currentDomainId, string pageSlug )
        {
            int pageId;

            if ( int.TryParse( pageSlug, out pageId ) )
            {
                return this.Pages.FirstOrDefault( s => s.DomainId == currentDomainId && s.PageId == pageId );
            }

            return this.Pages.FirstOrDefault( s => s.DomainId == currentDomainId && s.PageSlug == pageSlug );
        }
    }
}
