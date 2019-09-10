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
    public class CreateVehicleCommandHandlerTest
    {
        private readonly IVehicleRepositoryAsync vehicleRepositoryAsyncMock;
        private readonly IUnitOfWork unitOfWorkMock;
        private readonly CreateVehicleCommandHandler handler;

        public CreateVehicleCommandHandlerTest()
        {
            unitOfWorkMock = Substitute.For<IUnitOfWork>();
            vehicleRepositoryAsyncMock = Substitute.For<IVehicleRepositoryAsync>();

            handler = new CreateVehicleCommandHandler(vehicleRepositoryAsyncMock, unitOfWorkMock);
        }

        [Fact]
        public async Task CreateVehicleCommandHandler_Handler_ReturnThatVehicleExist()
        {
            vehicleRepositoryAsyncMock.GetAsync(Arg.Any<string>()).Returns(new VehicleBuilder().Builder());
            var command = new CreateVehicleCommandBuilder().Builder();

            var result = await handler.Handle(command, new CancellationToken());

            Assert.False(result.Success);
            Assert.Equal("Este veiculo já esta cadastrado", result.Message);
        }

        [Fact]
        public async Task CreateVehicleCommandHandler_Handler_IsAnErrorInCommit()
        {
            Vehicle vehicle = null;
            vehicleRepositoryAsyncMock.GetAsync(Arg.Any<string>()).Returns(vehicle);
            unitOfWorkMock.CommitAsnyc().Returns(false);

            var command = new CreateVehicleCommandBuilder().Builder();

            var result = await handler.Handle(command, new CancellationToken());

            Assert.False(result.Success);
        }

        [Fact]
        public async Task CreateVehicleCommandHandler_Handler_ExecuteCommit()
        {
            Vehicle vehicle = null;
            vehicleRepositoryAsyncMock.GetAsync(Arg.Any<string>()).Returns(vehicle);
            unitOfWorkMock.CommitAsnyc().Returns(true);

            var command = new CreateVehicleCommandBuilder().Builder();

            var result = await handler.Handle(command, new CancellationToken());

            Assert.True(result.Success);
        }

    }
}
