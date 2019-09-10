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
    public class RemoveVehicleCommandHandlerTest
    {
        private readonly IVehicleRepositoryAsync vehicleRepositoryAsyncMock;
        private readonly IUnitOfWork unitOfWorkMock;
        private readonly RemoveVehicleCommandHandler handler;

        public RemoveVehicleCommandHandlerTest()
        {
            unitOfWorkMock = Substitute.For<IUnitOfWork>();
            vehicleRepositoryAsyncMock = Substitute.For<IVehicleRepositoryAsync>();
            handler = new RemoveVehicleCommandHandler(vehicleRepositoryAsyncMock, unitOfWorkMock);
        }

        [Fact]
        public async Task RemoveVehicleCommandHandler_Handler_WasNotConfirmRemoved()
        {
            var command = new RemoveVehicleCommandBuilder().NotConfirm().Builder();
            var result = await handler.Handle(command, new CancellationToken());

            Assert.False(result.Success);
            Assert.Equal("Usuario não confirmou exclusão", result.Message);
        }

        [Fact]
        public async Task RemoveVehicleCommandHandler_Handler_ReturnThatVehicleNotExist()
        {
            Vehicle vehicle = null;
            vehicleRepositoryAsyncMock.GetAsync(Arg.Any<string>()).Returns(vehicle);

            var command = new RemoveVehicleCommandBuilder().Builder();
            var result = await handler.Handle(command, new CancellationToken());

            Assert.False(result.Success);
            Assert.Equal("Este veiculo não foi encontrado", result.Message);
        }

        [Fact]
        public async Task RemoveVehicleCommandHandler_Handler_RemoveSuccess()
        {
            Vehicle vehicle = new VehicleBuilder().Builder();
            vehicleRepositoryAsyncMock.GetAsync(Arg.Any<string>()).Returns(vehicle);
            unitOfWorkMock.CommitAsnyc().Returns(true);

            var command = new RemoveVehicleCommandBuilder().Builder();
            var result = await handler.Handle(command, new CancellationToken());

            Assert.True(result.Success);
        }
    }
}
