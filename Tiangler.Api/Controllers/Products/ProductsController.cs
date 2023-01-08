using Microsoft.AspNetCore.Mvc;
using Tiangler.Api.Controllers.Products.InputModels;
using Tiangler.Application.Commands.Products.Interfaces;

namespace Tiangler.Api.Controllers.Products
{
    [ApiController]
    [Route("api/companies/{companyId}/[controller]")]

    public class ProductsController : ControllerBase
    {
        private readonly ICreateProductCommand _createProductCommand;

        public ProductsController(
            ICreateProductCommand createProductCommand
        )
        {
            _createProductCommand = createProductCommand;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(CreateProductInputModel input)
        {
            await _createProductCommand.ExecuteCommand(input.ToDto());
            return Ok();
        }
    }
}