using InLogTest.Domain.Vehicles;
using InLogTest.Domain.Vehicles.CommandHandlers;
using InLogTest.Domain.Vehicles.Repositories;
using InLogTest.Shared.Interface;
using InLogTest.Test.Builder.Vehicles;
using InLogTest.Test.Builder.Vehicles.Commands;
using NSubstitute;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace InLogTest.UnitTest.Vehicles.CommandHandlerTests
{
    public class EditVehicleCommandHandlerTest
    {
        private readonly IVehicleRepositoryAsync vehicleRepositoryAsyncMock;
        private readonly IUnitOfWork unitOfWorkMock;
        private readonly EditVehicleCommandHandler handler;

        public EditVehicleCommandHandlerTest()
        {
            vehicleRepositoryAsyncMock = Substitute.For<IVehicleRepositoryAsync>();
            unitOfWorkMock = Substitute.For<IUnitOfWork>();
            handler = new EditVehicleCommandHandler(vehicleRepositoryAsyncMock, unitOfWorkMock);
        }

        [Fact]
        public async Task EditVehicleCommandHandler_Handler_ReturnVehicleIsNotExists()
        {

            Vehicle vehicle = null;
            vehicleRepositoryAsyncMock.GetAsync(Arg.Any<string>()).Returns(vehicle);
            var command = new EditVehicleCommandBuilder().Builder();
            var result = await handler.Handle(command, new CancellationToken());

            Assert.False(result.Success);
            Assert.Equal("Veiculo não encontrado", result.Message);
        }

        [Fact]
        public async Task EditVehicleCommandHandler_Handler_EditVehicleSuccess()
        {
            var color = "Green";
            Vehicle vehicle = new VehicleBuilder().Builder();
            vehicleRepositoryAsyncMock.GetAsync(Arg.Any<string>()).Returns(vehicle);
            unitOfWorkMock.CommitAsnyc().Returns(true);
            var command = new EditVehicleCommandBuilder().WithColor(color).Builder();
            var result = await handler.Handle(command, new CancellationToken());

            Assert.True(result.Success);
            Assert.Equal(color, vehicle.Color);
        }
    }
}
