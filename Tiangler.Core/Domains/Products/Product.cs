using Tiangler.Core.Domains.Companies;

namespace Tiangler.Core.Domains.Products
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public int Stocks { get; set; }
        public int LowStockLevel { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}