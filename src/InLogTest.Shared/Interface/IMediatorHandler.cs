using InLogTest.Shared.Commands;
using MediatR;
using System.Threading.Tasks;

namespace InLogTest.Shared.Interface
{
    public interface IMediatorHandler
    {
        Task<CommandResult> SendCommandAsync<TCommand>(TCommand command) where TCommand : IRequest<CommandResult>;
    }
}
