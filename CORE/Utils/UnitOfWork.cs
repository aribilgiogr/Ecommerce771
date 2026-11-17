using CORE.Abstracts.Bases;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace CORE.Utils
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext context;
        private ConcurrentDictionary<Type, object> repositories;

        public UnitOfWork(TContext context)
        {
            this.context = context;
            repositories = [];
        }

        public async Task<Reply> CommitAsync()
        {
            try
            {
                await context.SaveChangesAsync();
                return Reply.Success();
            }
            catch (Exception ex)
            {
                return Reply.Fail(ex.Message);
            }
        }

        public async ValueTask DisposeAsync() => await context.DisposeAsync();

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            return (IRepository<TEntity>)repositories.GetOrAdd(typeof(TEntity), _ => new Repository<TEntity>(context));
        }
    }
}
