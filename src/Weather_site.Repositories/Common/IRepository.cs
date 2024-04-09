using Weather_site.Core.Entities;

namespace Weather_site.Repositories.Common
{
    public interface IRepository
    {
        public interface IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        {
            Task<IEnumerable<TEntity>> GetAllAsync();
            Task<TEntity> GetAsync(TKey id);
            Task CreateAsync(TEntity entity);
            Task UpdateAsync(TEntity entity);
            Task DeleteAsync(TKey id);
            Task SaveAsync();
        }
    }
}
