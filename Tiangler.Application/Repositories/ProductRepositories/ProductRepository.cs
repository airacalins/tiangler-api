using Tiangler.Application.Contexts;
using Tiangler.Core.Domains.Products;

namespace Tiangler.Application.Repositories.ProductRepositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly IAppDbContext _context;
        public ProductRepository(IAppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Get(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) throw new NullReferenceException();

            return product;
        }

        public void Add(Product item)
        {
            _context.Products.Add(item);
        }

        public async Task Update(Guid id, Product item)
        {
            var product = await _context.Products.FindAsync(id);
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }


        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

    }
}