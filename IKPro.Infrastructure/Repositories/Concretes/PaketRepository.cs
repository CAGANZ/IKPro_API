using IKPro.Domain.Models;
using IKPro.Domain.Repositories.Abstract;
using IKPro.Infrastructure.Data;

namespace IKPro.Infrastructure.Repositories.Concretes
{
    public class PaketRepository : BaseRepository<Paket>, IPaketRepository
    {
        public PaketRepository(IKProDbContext context) : base(context)
        {
        }
    }
}
