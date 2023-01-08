using Tiangler.Application.Commands.Products.Dtos;
using Tiangler.Application.Commands.Products.Interfaces;
using Tiangler.Application.Repositories.ProductRepositories;
using Tiangler.Core.Domains.Products;

namespace Tiangler.Application.Commands.Products.Commands
{
    public class CreateProductCommand : ICreateProductCommand
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommand(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task ExecuteCommand(CreateProductDto input)
        {
            var product = new Product
            {
                ImageUrl = input.ImageUrl,
                Name = input.Name,
                Stocks = input.Stocks,
                LowStockLevel = input.LowStockLevel,
                Price = input.Price,
                Cost = input.Cost,
            };

            _productRepository.Add(product);

            await _productRepository.SaveChangesAsync();
        }
    }
}