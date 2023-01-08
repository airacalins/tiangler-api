using Tiangler.Application.Commands.Products.Dtos;

namespace Tiangler.Application.Commands.Products.Interfaces
{
    public interface IUpdateProductCommand
    {
        Task ExecuteCommand(Guid id, UpdateProductDto item);
    }
}