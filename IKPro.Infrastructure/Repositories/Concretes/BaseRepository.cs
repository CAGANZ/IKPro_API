using IKPro.Domain.Repositories.Abstract;
using IKPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IKPro.Infrastructure.Repositories.Concretes
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly IKProDbContext _context;
        protected readonly DbSet<TEntity> _table;
        public BaseRepository(IKProDbContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }
        public async Task<TEntity> BulAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<int> EkleAsync(TEntity entity)
        {
            var result = await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return (int)result.Property(result.Metadata.FindPrimaryKey().Properties.FirstOrDefault()).CurrentValue;
        }

        public async Task<bool> GuncelleAsync(TEntity entity)
        {
            _table.Update(entity);
            return await _context.SaveChangesAsync()>0?true:false;
        }
        public async Task<IEnumerable<TEntity>> ListeAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<bool> SilAsync(int id)
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
