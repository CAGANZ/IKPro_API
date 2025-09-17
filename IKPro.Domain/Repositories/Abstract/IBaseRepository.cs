
namespace IKPro.Domain.Repositories.Abstract
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<int> EkleAsync(TEntity entity);
        Task<bool> GuncelleAsync(TEntity entity);
        Task<bool> SilAsync(int id);
        Task<TEntity> BulAsync(int id);
        Task<IEnumerable<TEntity>> ListeAsync();
    }
}
