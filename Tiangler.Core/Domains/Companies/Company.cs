using System.ComponentModel.DataAnnotations.Schema;
using Tiangler.Core.Domains.ApplicationUsers;

namespace Tiangler.Core.Domains.Companies
{
    public class Company
    {
        protected Company() { }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid CompanyId { get; private set; }
        public string CompanyName { get; private set; }
        public Guid CompanyAdmin { get; private set; }
        [ForeignKey("CompanyAdmin")]
        public ApplicationUser ApplicationUser { get; set; }

        protected Company Create(string companyName, Guid userId)
        {
            return new Company
            {
                CompanyId = Guid.NewGuid(),
                CompanyName = companyName,
                CompanyAdmin = userId
            };
        }
    }
}
