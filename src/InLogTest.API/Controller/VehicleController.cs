using InLogTest.API.ViewModels;
using InLogTest.Domain.Vehicles.Commands;
using InLogTest.Domain.Vehicles.Repositories;
using InLogTest.Shared.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InLogTest.API.Controller
{
    [Route("v1/[controller]")]
    public class VehicleController : BaseController
    {
        private readonly IMediatorHandler mediator;
        private readonly IVehicleRepositoryAsync repositoryAsync;

        public VehicleController(IMediatorHandler mediator, IVehicleRepositoryAsync repositoryAsync)
        {
            this.mediator = mediator;
            this.repositoryAsync = repositoryAsync;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await repositoryAsync.GetAsync();
            return await ResponseBase(true, "Veiculos Cadastrados", result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string chassis)
        {
            var result = await repositoryAsync.GetAsync(chassis);
            if(result == null)
            {
                return await ResponseBase(false, "Veiculo não encontrado", null);
            }
            return await ResponseBase(true, "Veiculo", result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateVehicleViewModel viewModel)
        {
            if (!viewModel.Validate())
            {
                return await ResponseBase(viewModel.Notifications);
            }

            var command = new CreateVehicleCommand(viewModel.Chassis, viewModel.Color, viewModel.Type);
            var result = await mediator.SendCommandAsync(command);

            return await ResponseBase(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditVehicleViewModel viewModel)
        {
            if (!viewModel.Validate())
            {
                return await ResponseBase(viewModel.Notifications);
            }

            var command = new EditVehicleCommand(viewModel.Chassis, viewModel.Color);
            var result = await mediator.SendCommandAsync(command);

            return await ResponseBase(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string chassis, [FromQuery] bool confirm)
        {

            var command = new RemoveVehicleCommand(chassis, confirm);
            var result = await mediator.SendCommandAsync(command);

            return await ResponseBase(result);
        }
    }
}
