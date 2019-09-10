using InLogTest.Domain.Vehicles.Commands;
using InLogTest.Domain.Vehicles.Enums;

namespace InLogTest.Test.Builder.Vehicles.Commands
{
    public class CreateVehicleCommandBuilder
    {
        private string chassis;
        private string color;
        private int type;

        public CreateVehicleCommandBuilder()
        {
            chassis = "3443943943849849";
            color = "Black";
            type = 1;
        }

        public CreateVehicleCommand Builder() => new CreateVehicleCommand(chassis, color, type);

        public CreateVehicleCommandBuilder WithChassis(string value)
        {
            chassis = value;
            return this;
        }
        public CreateVehicleCommandBuilder WithColor(string value)
        {
            color = value;
            return this;
        }
        public CreateVehicleCommandBuilder IsBus()
        {
            type = (int)VehicleType.Bus;
            return this;
        }
        public CreateVehicleCommandBuilder IsTruck()
        {
            type = (int)VehicleType.Truck;
            return this;
        }
    }
}
