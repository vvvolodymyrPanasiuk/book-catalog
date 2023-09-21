namespace BookCatalog.Domain.Repositories
{
    /// <summary>
    /// Represents a generic repository for managing entities of type TEntity.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets an IQueryable representing all entities of type TEntity.
        /// </summary>
        /// <returns>An IQueryable representing all entities.</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Gets all entities of type TEntity.
        /// </summary>
        /// <returns>A list of entities.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Gets an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity with the specified ID, or null if not found.</returns>
        Task<TEntity> GetByIdAsync(Guid id);

        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity with its assigned ID.</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The updated entity data.</param>
        /// <returns>The updated entity data.</returns>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// Deletes an entity from the repository by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to delete.</param>
        Task DeleteAsync(Guid id);
    }
}
