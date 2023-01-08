using Tiangler.Application.Commands.Products.Dtos;

namespace Tiangler.Application.Commands.Products.Interfaces
{
    public interface ICreateProductCommand
    {
        Task ExecuteCommand(CreateProductDto input);
    }
}