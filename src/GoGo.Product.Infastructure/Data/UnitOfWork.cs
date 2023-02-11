using GoGo.Product.Domain.Bases;
using GoGo.Product.Domain.Repos;

namespace GoGo.Product.Infastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        
        private readonly ProductDbContext _productDbContext;
        private readonly Dictionary<Type, object> _repos;

        public UnitOfWork(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
            _repos = new Dictionary<Type, object>();
        }

        public async Task BeginTransactionAsync()
        {
            await _productDbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _productDbContext.Database.CommitTransactionAsync();
        }

        public IRepository<TEntity> Repo<TEntity>() where TEntity : CoreEntity
        {
            var type = typeof(TEntity);
            if(!_repos.ContainsKey(type))
            {
                _repos.Add(type, new ProductRepository<TEntity>(_productDbContext));
            }

            return (IRepository<TEntity>)_repos[type];
        }

        public async Task RollbackTransactionAsync()
        {
            await _productDbContext.Database.RollbackTransactionAsync();
        }

        public bool SaveChange()
        {
            return _productDbContext.SaveChanges() > 0;
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _productDbContext.SaveChangesAsync();
        }

        public async Task<bool> SaveChangeAsync(CancellationToken cancellationToken)
        {
            return await _productDbContext.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}