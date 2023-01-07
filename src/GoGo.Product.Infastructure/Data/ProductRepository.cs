using Microsoft.EntityFrameworkCore;
using GoGo.Product.Domain.Bases;
using GoGo.Product.Domain.Repos;
using System.Linq.Expressions;

namespace GoGo.Product.Infastructure.Data
{
    public class ProductRepository<TEntity> : IRepository<TEntity> where TEntity : CoreEntity
    {
        protected readonly ProductDbContext _productDbContext;
        protected DbSet<TEntity> DbSet => _productDbContext.Set<TEntity>();
        
        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
            _productDbContext.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).AsNoTracking();
        }

        public async Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).AsNoTracking().ToListAsync();
        }

        public  IQueryable<TEntity> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
    }
}