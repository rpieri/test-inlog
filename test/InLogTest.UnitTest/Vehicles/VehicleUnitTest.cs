using InLogTest.Domain.Vehicles;
using InLogTest.Test.Builder.Vehicles;
using System.Linq;
using Xunit;

namespace InLogTest.UnitTest.Vehicles
{
    public class VehicleUnitTest
    {
        [Fact]
        public void Vehicle_CreateANewVehicle_DontSendChassi_ResultInvalid()
        {
            var vehicle = new VehicleBuilder().WithChassis(string.Empty).Builder();
            Assert.True(vehicle.Invalid);
            Assert.Contains("Chassi", vehicle.Notifications.Select(x => x.Property));
        }

        [Fact]
        public void Vehicle_CreateANewVehicle_DontSendColor_ResultInvalid()
        {
            var vehicle = new VehicleBuilder().WithColor(string.Empty).Builder();
            Assert.True(vehicle.Invalid);
            Assert.Contains("Color", vehicle.Notifications.Select(x => x.Property));
        }

        [Fact]
        public void Vehicle_CreateANewVehicle_SendChassi_ResultValid()
        {
            var vehicle = new VehicleBuilder().Builder();
            Assert.True(vehicle.Valid);
        }

        [Fact]
        public void Vehicle_CreateANewVehicle_TypeBuss_NumberOfPassagers_Is42()
        {
            var vehicle = new VehicleBuilder().Builder();
            Assert.True(vehicle.Valid);
            Assert.Equal(42, vehicle.NumberOfPassagers);
        }

        [Fact]
        public void Vehicle_CreateANewVehicle_TypeTruck_NumberOfPassagers_Is42()
        {
            var vehicle = new VehicleBuilder().IsTruck().Builder();
            Assert.True(vehicle.Valid);
            Assert.Equal(2, vehicle.NumberOfPassagers);
        }

    }
}
