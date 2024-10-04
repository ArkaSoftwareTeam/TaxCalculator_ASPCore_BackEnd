using CTaxCalculator.Framework.Core.ApplicationServices.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Commands;

namespace CTaxCalculator.Src.Endpoints.API.CustomDecorators;

public class CustomCommandDecorator : CommandDispatcherDecorator
{
    public override int Order => 0;

    public override async Task<CommandResult> Send<TCommand>(TCommand command)
    {
        return await _commandDispatcher.Send(command);
    }

    public override async Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command)
    {
        return await _commandDispatcher.Send<TCommand, TData>(command);
    }
}