using InLogTest.Domain.Vehicles.Enums;
using InLogTest.Shared.Commands;

namespace InLogTest.Domain.Vehicles.Commands
{
    public class CreateVehicleCommand : VehicleBaseCommand
    {
        public CreateVehicleCommand(string chassis, string color, int type)
        {
            Chassis = chassis;
            Color = color;
            Type = (VehicleType)type;
        }
    }
}
