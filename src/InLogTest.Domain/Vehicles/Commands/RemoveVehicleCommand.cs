namespace InLogTest.Domain.Vehicles.Commands
{
    public class RemoveVehicleCommand : VehicleBaseCommand
    {
        public bool Confirm { get; private set; }

        public RemoveVehicleCommand(string chassis, bool confirm)
        {
            Chassis = chassis;
            Confirm = confirm;
        }
    }
}
