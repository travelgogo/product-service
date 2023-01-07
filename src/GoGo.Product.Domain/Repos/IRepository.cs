using GoGo.Product.Domain.Bases;
using System.Linq.Expressions;

namespace GoGo.Product.Domain.Repos
{
    public interface IRepository<TEntity> where TEntity : CoreEntity
    {
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        Task<TEntity?> GetByIdAsync(int id);
    }
}