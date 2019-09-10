using Flunt.Notifications;
using InLogTest.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InLogTest.API.Controller
{
    public abstract class BaseController : ControllerBase
    {
        protected async Task<ActionResult> ResponseBase(CommandResult commandResult)
        {
            if (commandResult.Success)
            {
                return await Task.Run(() => new OkObjectResult(commandResult));
            }

            return await Task.Run(() => new BadRequestObjectResult(commandResult));
        }

        protected async Task<ActionResult> ResponseBase(IEnumerable<Notification> notifications)
            => await Task.Run(() => new BadRequestObjectResult(new CommandResult(false, "Dados informados errados", notifications)));

        protected async Task<ActionResult> ResponseBase(bool sucess, string message,object result)
        {
            if (sucess)
            {
                return await Task.Run(() => new OkObjectResult(new CommandResult(sucess, message, result)));
            }
            return await Task.Run(() => new BadRequestObjectResult(new CommandResult(sucess, message, result)));
        } 

    }
}
