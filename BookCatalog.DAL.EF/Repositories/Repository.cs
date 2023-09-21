using BookCatalog.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.DAL.EF.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly BookCatalogDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(BookCatalogDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }


        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
