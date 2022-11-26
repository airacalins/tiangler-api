using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiangler.Application.Commands.Companies.Dtos;
using Tiangler.Core.ResultModels;

namespace Tiangler.Application.Commands.Companies.Interfaces
{
    public interface IGetUserCompaniesCommand
    {
        Task<CommandResult<List<GetCompanyDto>>> ExecuteAsync(Guid userId);
    }
}
