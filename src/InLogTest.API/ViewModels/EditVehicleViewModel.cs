using Flunt.Notifications;
using Flunt.Validations;

namespace InLogTest.API.ViewModels
{
    public class EditVehicleViewModel : Notifiable
    {
        public string Chassis { get; set; }
        public string Color { get; set; }

        public bool Validate()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Chassis, "Chassi", "Chassi deve ser informado")
                .IsNotNullOrEmpty(Color, "cor", "Cor deve ser infomada"));
           
            return Valid;
        }
    }
}
