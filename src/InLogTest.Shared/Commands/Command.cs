using MediatR;

namespace InLogTest.Shared.Commands
{
    public abstract class Command: IRequest<CommandResult>
    {
    }
}
