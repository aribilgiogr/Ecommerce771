using CORE.Abstracts.Bases;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CORE.Utils
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext context;
        private readonly DbSet<TEntity> set;

        public Repository(DbContext context)
        {
            this.context = context;
            set = this.context.Set<TEntity>();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? expression = null)
        {
            // (_ => true): Bütün kayıtlar anlamına gelir.
            return await set.AnyAsync(expression ?? (_ => true));
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? expression = null)
        {
            return await set.CountAsync(expression ?? (_ => true));
        }

        public void DeleteMany(IEnumerable<TEntity> entities)
        {
            set.RemoveRange(entities);
        }

        public void DeleteOne(TEntity entity)
        {
            set.Remove(entity);
        }

        public async Task InsertManyAsync(IEnumerable<TEntity> entities)
        {
            await set.AddRangeAsync(entities);
        }

        public async Task InsertOneAsync(TEntity entity)
        {
            await set.AddAsync(entity);
        }

        public IQueryable<TEntity> Query()
        {
            return set;
        }

        public void UpdateMany(IEnumerable<TEntity> entities)
        {
            set.UpdateRange(entities);
        }

        public void UpdateOne(TEntity entity)
        {
            set.Update(entity);
        }
    }
}
