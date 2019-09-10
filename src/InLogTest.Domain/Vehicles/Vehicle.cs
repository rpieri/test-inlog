using System;
using Flunt.Validations;
using InLogTest.Domain.Vehicles.Enums;
using InLogTest.Shared.Models;

namespace InLogTest.Domain.Vehicles
{
    public class Vehicle : Entity
    {
        public Vehicle(string chassis, string color, VehicleType type)
        {
            Chassis = chassis;
            Color = color;
            Type = type;

            if(Type == VehicleType.Bus)
            {
                NumberOfPassagers = 42;
            }
            else
            {
                NumberOfPassagers = 2;
            }

            AddNotifications(new Contract()
                .IsNotNullOrEmpty(chassis, "Chassi", "Chassi deve ser informado")
                .HasMaxLen(chassis, 250, "Chassi", "Chassi deve conter no maximo 250 caracteres")
                .IsNotNullOrEmpty(color, "cor", "Cor deve ser infomada")
                .HasMaxLen(color, 50, "Cor", "cor deve conter no maximo 50 caracteres"));
        }

        public string Chassis { get; private set; }
        public string Color { get; private set; }
        public VehicleType Type { get; private set; }
        public byte NumberOfPassagers {get; private set;}

        public void Update(string color) => Color = color;
        protected Vehicle()
        {

        }
    }
}
