using Microsoft.AspNetCore.Mvc;
using Tiangler.Api.Models;
using Tiangler.Core.ResultModels;

namespace Tiangler.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected Guid GetUserId()
        {
            return new Guid(this.User.Claims.First(i => i.Type == "UserId").Value);
        }

        protected BadRequestObjectResult Error<T>(CommandResult<T> commandResult)
        {
            var errorVms = new List<ErrorViewModel>();
            if (commandResult.Errors != null && commandResult.Errors.Any())
            {
                foreach (var item in commandResult.Errors)
                {
                    errorVms.Add(new ErrorViewModel(item.Value.Code, item.Value.Message));
                }

                return BadRequest(errorVms);
            }
            else
            {
                return BadRequest(new ErrorViewModel(commandResult.Error.Value.Code, commandResult.Error.Value.Message));
            }
        }
    }
}
