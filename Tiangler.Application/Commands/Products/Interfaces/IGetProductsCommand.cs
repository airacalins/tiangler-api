using Tiangler.Core.Domains.Products;

namespace Tiangler.Application.Commands.Products.Interfaces
{
    public interface IGetProductsCommand
    {
        Task<List<Product>> ExecuteCommand(Guid companyId);
    }
}