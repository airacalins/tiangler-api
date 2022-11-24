using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiangler.Core.Domains.ApplicationUsers;

namespace Tiangler.Core.Domains.Companies
{
    public class Company
    {
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public Guid CompanyAdmin { get; set; }
        [ForeignKey("CompanyAdmin")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
