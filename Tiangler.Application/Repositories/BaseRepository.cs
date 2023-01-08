using Tiangler.Application.Contexts;

namespace Tiangler.Application.Repositories
{
    public abstract class BaseRepository
    {
        private readonly IAppDbContext _context;
        public BaseRepository(IAppDbContext context)
        {
            _context = context;
        }
    }
}