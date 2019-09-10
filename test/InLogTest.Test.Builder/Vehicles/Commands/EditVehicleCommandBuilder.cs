using InLogTest.Domain.Vehicles.Commands;

namespace InLogTest.Test.Builder.Vehicles.Commands
{
    public class EditVehicleCommandBuilder
    {
        private string chassis;
        private string color;

        public EditVehicleCommandBuilder()
        {
            chassis = "456454464564564";
            color = "Red";
        }

        public EditVehicleCommand Builder() => new EditVehicleCommand(chassis, color);

        public EditVehicleCommandBuilder WithChassis(string value)
        {
            chassis = value;
            return this;
        }

        public EditVehicleCommandBuilder WithColor(string value)
        {
            color = value;
            return this;
        }
    }
}
