using InLogTest.Domain.Vehicles.Enums;
using InLogTest.Shared.Commands;

namespace InLogTest.Domain.Vehicles.Commands
{
    public abstract class VehicleBaseCommand : Command
    {
        public string Chassis { get; protected set; }
        public string Color { get; protected set; }
        public VehicleType Type { get; protected set; }

    }
}
