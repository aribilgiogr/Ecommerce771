using CORE.Abstracts.Bases;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace CORE.Utils
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        Task<Reply> CommitAsync();
    }

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

    public class Reply
    {
        public bool IsSuccess { get; }
        public IEnumerable<string>? Errors { get; }

        public Reply(bool isSuccess, IEnumerable<string>? errors = null)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public static Reply Success() => new(true);
        public static Reply Fail() => new(false);
        public static Reply Fail(string error) => new(false, [error]);
        public static Reply Fail(IEnumerable<string> errors) => new(false, errors);
    }
}
