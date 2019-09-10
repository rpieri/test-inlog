using Flunt.Notifications;
using InLogTest.Shared.Commands;
using InLogTest.Shared.Interface;
using System.Threading.Tasks;

namespace InLogTest.Shared.Handlers
{
    public abstract class CommandHandler : Notifiable
    {
        private readonly IUnitOfWork unitOfWork;

        public CommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected async Task<CommandResult> CommitAsync()
        {
            if (await unitOfWork.CommitAsnyc())
            {
                return new CommandResult(true, "Entidade gravada com sucesso no banco de dados");
            }
            return new CommandResult(false, "Entidade não foi inserida no banco de dados");
        }

        protected Task<CommandResult> CreateErrorResultAsync(string message)  
            => Task.FromResult(new CommandResult(false, message, Notifications));

        protected Task<CommandResult> CreateResultAsync(bool sucess, string message)
            => Task.FromResult(new CommandResult(sucess, message));

    }
}
