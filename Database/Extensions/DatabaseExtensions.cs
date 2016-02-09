using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystemDatabase.BaseClasses;

namespace ContentManagementSystemDatabase
{
    public static class DatabaseExtensions
    {
        public static IQueryable<T> WhereActive<T>( this DbSet<T> dbSet ) where T : EntityBase
        {
            return dbSet.Where( d => d.IsDeleted == false );
        }

        public static IQueryable<T> WhereActive<T>( this IQueryable<T> set ) where T : EntityBase
        {
            return set.Where( s => s.IsDeleted == false );
        }

        public static IOrderedQueryable<T> OrderByDateCreated<T>( this DbSet<T> dbSet ) where T : EntityBase
        {
            return dbSet.OrderBy( d => d.DateCreated );
        }

        public static IOrderedQueryable<T> OrderByDateCreated<T>( this IQueryable<T> set ) where T : EntityBase
        {
            return set.OrderBy( d => d.DateCreated );
        }

        public static IOrderedQueryable<T> OrderByDescendingDateCreated<T>( this DbSet<T> dbSet ) where T : EntityBase
        {
            return dbSet.OrderByDescending( d => d.DateCreated );
        }

        public static IOrderedQueryable<T> OrderByDescendingDateCreated<T>( this IQueryable<T> set ) where T : EntityBase
        {
            return set.OrderByDescending( d => d.DateCreated );
        }

        public static IOrderedQueryable<T> OrderByDateUpdated<T>( this DbSet<T> dbSet ) where T : EntityBase
        {
            return dbSet.OrderBy( d => d.DateUpdated );
        }

        public static IOrderedQueryable<T> OrderByDateUpdated<T>( this IQueryable<T> set ) where T : EntityBase
        {
            return set.OrderBy( d => d.DateUpdated );
        }

        public static IOrderedQueryable<T> OrderByDescendingDateUpdated<T>( this DbSet<T> dbSet ) where T : EntityBase
        {
            return dbSet.OrderByDescending( d => d.DateUpdated );
        }

        public static IOrderedQueryable<T> OrderByDescendingDateUpdated<T>( this IQueryable<T> set ) where T : EntityBase
        {
            return set.OrderByDescending( d => d.DateUpdated );
        }

        //public static IOrderedQueryable<T> OrderByName<T>( this DbSet<T> dbSet ) where T : INamedBase
        //{
        //    return dbSet.OrderBy( d => d.Name );
        //}

        //public static IOrderedQueryable<T> OrderByName<T>( this IQueryable<T> set ) where T : INamedBase
        //{
        //    return set.OrderBy( s => s.Name );
        //}

        public static bool CanAccess( this UserProfile user, IDomainRestricted domain )
        {
            if ( user.IsAdministrator ) return true;

            return ( user.DomainId == domain.DomainId );
        }

        public static bool CanModify( this UserProfile user, IDomainRestricted domain )
        {
            if ( user.IsAdministrator ) return true;

            return ( user.DomainId == domain.DomainId );
        }
    }
}
