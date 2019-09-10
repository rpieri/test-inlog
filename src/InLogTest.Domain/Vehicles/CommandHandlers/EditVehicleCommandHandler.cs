using System.Threading;
using System.Threading.Tasks;
using InLogTest.Domain.Vehicles.Commands;
using InLogTest.Domain.Vehicles.Repositories;
using InLogTest.Shared.Commands;
using InLogTest.Shared.Handlers;
using InLogTest.Shared.Interface;
using MediatR;

namespace InLogTest.Domain.Vehicles.CommandHandlers
{
    public class EditVehicleCommandHandler : CommandHandler, IRequestHandler<EditVehicleCommand, CommandResult>
    {
        private readonly IVehicleRepositoryAsync vehicleRepositoryAsync;
        public EditVehicleCommandHandler(
            IVehicleRepositoryAsync vehicleRepositoryAsync,
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.vehicleRepositoryAsync = vehicleRepositoryAsync;
        }

        public async Task<CommandResult> Handle(EditVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = await vehicleRepositoryAsync.GetAsync(request.Chassis);
            if(vehicle == null)
            {
                return await CreateResultAsync(false, "Veiculo não encontrado");
            }

            vehicle.Update(request.Color);

            await vehicleRepositoryAsync.UpdateAsync(vehicle);
            return await CommitAsync();
        }
    }
}
