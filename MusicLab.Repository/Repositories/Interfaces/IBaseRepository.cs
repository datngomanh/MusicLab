using System.Linq.Expressions;

namespace MusicLab.Repository.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
        Task<T> GetById(string id);
        Task Add(T entity);
        Task Delete(T entity);
        Task DeleteRange(List<T> entity);
        Task Update(T entity);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
