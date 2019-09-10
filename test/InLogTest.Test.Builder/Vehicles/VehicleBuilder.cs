using InLogTest.Domain.Vehicles;
using InLogTest.Domain.Vehicles.Enums;

namespace InLogTest.Test.Builder.Vehicles
{
    public class VehicleBuilder
    {
        private string chassis;
        private string color;
        private VehicleType type;

        public VehicleBuilder()
        {
            chassis = "4554897458456464564456466";
            color = "Black";
            type = VehicleType.Bus;
        }

        public Vehicle Builder() => new Vehicle(chassis, color, type);

        public VehicleBuilder WithChassis(string value)
        {
            chassis = value;
            return this;
        }

        public VehicleBuilder WithColor(string value)
        {
            color = value;
            return this;
        }

        public VehicleBuilder IsBus()
        {
            type = VehicleType.Bus;
            return this;
        }

        public VehicleBuilder IsTruck()
        {
            type = VehicleType.Truck;
            return this;
        }
    }
}
