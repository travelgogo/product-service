using GoGo.Product.Domain.Bases;

namespace GoGo.Product.Domain.Repos
{
    public interface IBaseDb
    {
        IRepository<TEntity> Repo<TEntity>() where TEntity : CoreEntity;
        Task BeginTransactionAsync();
        Task RollbackTransactionAsync();
        Task CommitTransactionAsync();
        bool SaveChange();
        Task<int> SaveChangeAsync();
        Task<int> SaveChangeAsync(CancellationToken cancellationToken);
    }
}