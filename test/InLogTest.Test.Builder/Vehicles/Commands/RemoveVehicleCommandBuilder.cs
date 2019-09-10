using InLogTest.Domain.Vehicles.Commands;

namespace InLogTest.Test.Builder.Vehicles.Commands
{
    public class RemoveVehicleCommandBuilder
    {
        private string chassis;
        private bool confirm;

        public RemoveVehicleCommandBuilder()
        {
            chassis = "5454685454564";
            confirm = true;
        }

        public RemoveVehicleCommand Builder() => new RemoveVehicleCommand(chassis, confirm);

        public RemoveVehicleCommandBuilder WithChassis(string value)
        {
            chassis = value;
            return this;
        }

        public RemoveVehicleCommandBuilder Confirm()
        {
            confirm = true;
            return this;
        }

        public RemoveVehicleCommandBuilder NotConfirm()
        {
            confirm = false;
            return this;
        }
    }
}
