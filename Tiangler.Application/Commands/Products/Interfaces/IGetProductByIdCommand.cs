using Tiangler.Core.Domains.Products;

namespace Tiangler.Application.Commands.Products.Interfaces
{
    public interface IGetProductByIdCommand
    {
        Task<Product> ExecuteCommand(Guid id);
    }
}