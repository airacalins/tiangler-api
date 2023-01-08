using Tiangler.Application.Commands.Products.Dtos;

namespace Tiangler.Api.Controllers.Products.InputModels
{
    public class CreateProductInputModel
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public int Stocks { get; set; }
        public int LowStockLevel { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }

        public CreateProductDto ToDto()
        {
            var result = new CreateProductDto
            {
                ImageUrl = ImageUrl,
                Name = Name,
                Stocks = Stocks,
                LowStockLevel = LowStockLevel,
                Price = Price,
                Cost = Cost,
            };

            return result;
        }
    }
}