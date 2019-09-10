using Flunt.Notifications;
using Flunt.Validations;

namespace InLogTest.API.ViewModels
{
    public class CreateVehicleViewModel : Notifiable
    {
        public string Chassis { get; set; }
        public string Color { get; set; }
        public int Type { get; set; }

        public bool Validate()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Chassis, "Chassi", "Chassi deve ser informado")
                .HasMaxLen(Chassis, 250, "Chassi", "Chassi deve conter no maximo 250 caracteres")
                .IsNotNullOrEmpty(Color, "cor", "Cor deve ser infomada")
                .HasMaxLen(Color, 50, "Cor", "cor deve conter no maximo 50 caracteres")
                .IsGreaterThan(Type, 0,"Tipo", "Deve ser informado o tipo do veiculo"));

            return Valid;
        }
    }
}
