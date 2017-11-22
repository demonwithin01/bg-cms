using System.Data.Entity;

namespace ContentManagementSystemDatabase
{
    /// <summary>
    /// Defines new functionality to database entity sets.
    /// </summary>
    public static class DbSetExtensions
    {
        /// <summary>
        /// Creates a new database entity and automatically adds it to the database set.
        /// </summary>
        /// <typeparam name="TEntity">The database entity type</typeparam>
        /// <param name="dbset">The database set</param>
        /// <returns>A new database entity</returns>
        public static TEntity AddNew<TEntity>( this DbSet<TEntity> dbset ) where TEntity : class
        {
            TEntity entity = dbset.Create();

            dbset.Add( entity );

            return entity;
        }
    }
}
