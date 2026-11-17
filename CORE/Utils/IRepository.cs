using CORE.Abstracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CORE.Utils
{
    // Sadece BaseEntity sınıfından türetilmiş tiplerle çalışır.
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        // Create
        Task InsertOneAsync(TEntity entity);
        Task InsertManyAsync(IEnumerable<TEntity> entities);

        // Read
        IQueryable<TEntity> Query();

        // Update
        void UpdateOne(TEntity entity);
        void UpdateMany(IEnumerable<TEntity> entities);

        // Delete
        void DeleteOne(TEntity entity);
        void DeleteMany(IEnumerable<TEntity> entities);

        // Extras:
        // CountAsync(x => x.CategoryId == 3)
        Task<int> CountAsync(Expression<Func<TEntity, bool>>? expression = null);

        // AnyAsync(x => x.CategoryId == 3)
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? expression = null);
    }
}
