namespace CTaxCalculator.Framework.Core.RequestResponse.Commands
{

    /// <summary>
    /// This interface is used to mark a class that contains the input parameters for a command.
    /// </summary>
    public interface ICommand
    {
    }

    /// <summary>
    /// This interface is used to mark a class that contains the input parameters for a command.
    /// If a value should be returned in response to the sent command, this interface should be used.
    /// </summary>
    /// <typeparam name="TData">The type of data that should be returned in response to the command.</typeparam>
    public interface ICommand<TData>
    {
    }

}
