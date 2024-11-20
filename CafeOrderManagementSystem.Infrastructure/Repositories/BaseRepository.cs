using CafeOrderManagementSystem.Domain.Entities;
using CafeOrderManagementSystem.Infrastructure.Context;
using GenericRepository;

namespace CafeOrderManagementSystem.Infrastructure.Repositories
{
    public class BaseRepository<T> : Repository<T, ApplicationDbContext>, IRepository<T> where T : class
    {
        public BaseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
