using System.Threading.Tasks;
using InLogTest.Shared.Commands;
using InLogTest.Shared.Interface;
using MediatR;

namespace InLogTest.Shared.Handlers
{
    public sealed class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator mediator;

        public MediatorHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<CommandResult> SendCommandAsync<TCommand>(TCommand command)
            where TCommand : IRequest<CommandResult>
            => await mediator.Send(command);
        
    }
}
