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
    public class CreateVehicleCommandHandler : CommandHandler, IRequestHandler<CreateVehicleCommand, CommandResult>
    {
        private readonly IVehicleRepositoryAsync vehicleRepositoryAsync;
        public CreateVehicleCommandHandler(
            IVehicleRepositoryAsync vehicleRepositoryAsync,
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.vehicleRepositoryAsync = vehicleRepositoryAsync;
        }

        public async Task<CommandResult> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = await vehicleRepositoryAsync.GetAsync(request.Chassis);
            if(vehicle != null)
            {
                return await CreateResultAsync(false, "Este veiculo já esta cadastrado");
            }

            vehicle = new Vehicle(request.Chassis, request.Color, request.Type);
            AddNotifications(vehicle.Notifications);

            if (Invalid)
            {
                return await CreateErrorResultAsync("Campos incorretos ao gravar o veiculo");
            }

            await vehicleRepositoryAsync.AddAsync(vehicle);
            return await CommitAsync();
        }
    }
}
