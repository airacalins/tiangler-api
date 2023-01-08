using Tiangler.Core.Domains.Companies;

namespace Tiangler.Application.Commands.Products.Dtos
{
    public class UpdateProductDto
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public int Stocks { get; set; }
        public int LowStockLevel { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
    }
}