using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystemDatabase
{
    public static class DbSetExtensions
    {
        /// <summary>
        /// Creates a new database entity and automatically adds it to the database set.
        /// </summary>
        /// <typeparam name="TEntity">The database entity type</typeparam>
        /// <param name="dbset">The database set</param>
        /// <returns>A new database entity</returns>
        public static TEntity CreateAdd<TEntity>( this DbSet<TEntity> dbset ) where TEntity : class
        {
            TEntity entity = dbset.Create();

            dbset.Add( entity );

            return entity;
        }
    }
}
