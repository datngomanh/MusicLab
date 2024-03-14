using MusicLab.Repository.Models;
using MusicLab.Repository.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MusicLab.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MusicLabContext _context;

        public BaseRepository(MusicLabContext context)
        {
            _context = context;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id).ConfigureAwait(false);
        }
        public virtual async Task<T> GetById(string id)
        {
            return await _context.Set<T>().FindAsync(id).ConfigureAwait(false);
        }

        public virtual async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual async Task DeleteRange(List<T> entity)
        {
            _context.Set<T>().RemoveRange(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
    }
}
