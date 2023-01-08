using Tiangler.Application.Commands.Products.Interfaces;
using Tiangler.Application.Repositories.ProductRepositories;

namespace Tiangler.Application.Commands.Products.Commands
{
    public class DeleteProductCommand : IDeleteProductCommand
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommand(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task ExecuteCommand(Guid id)
        {
            await _productRepository.Delete(id);
            await _productRepository.SaveChangesAsync();

        }
    }
}