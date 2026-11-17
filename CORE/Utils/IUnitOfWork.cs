using CORE.Abstracts.Bases;

namespace CORE.Utils
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        Task<Reply> CommitAsync();
    }
}
