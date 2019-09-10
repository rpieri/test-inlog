namespace InLogTest.Domain.Vehicles.Commands
{
    public class EditVehicleCommand : VehicleBaseCommand 
    {
        public EditVehicleCommand(string chassis, string color)
        {
            Chassis = chassis;
            Color = color;
        }
    }
}
