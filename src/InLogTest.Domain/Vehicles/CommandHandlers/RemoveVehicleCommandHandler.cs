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
    public class RemoveVehicleCommandHandler : CommandHandler, IRequestHandler<RemoveVehicleCommand, CommandResult>
    {
        private readonly IVehicleRepositoryAsync vehicleRepositoryAsync;
        public RemoveVehicleCommandHandler(
            IVehicleRepositoryAsync vehicleRepositoryAsync,
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.vehicleRepositoryAsync = vehicleRepositoryAsync;
        }

        public async Task<CommandResult> Handle(RemoveVehicleCommand request, CancellationToken cancellationToken)
        {
            if (!request.Confirm)
            {
                return await CreateResultAsync(false, "Usuario não confirmou exclusão");
            }

            var vehicle = await vehicleRepositoryAsync.GetAsync(request.Chassis);
            if (vehicle == null)
            {
                return await CreateResultAsync(false, "Este veiculo não foi encontrado");
            }

            await vehicleRepositoryAsync.DeleteAsync(vehicle);
            return await CommitAsync();

        }
    }
}
