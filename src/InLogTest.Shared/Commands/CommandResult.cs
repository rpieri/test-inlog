namespace InLogTest.Shared.Commands
{
    public sealed class CommandResult
    {
        public CommandResult(bool success, string message)
        {
            CreateCommandResult(success, message);
        }

        public CommandResult(bool success, string message, object data)
        {
            CreateCommandResult(success, message);
            Data = data;
        }

        public void CreateCommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; private set; }
        public string Message { get; private set; }
        public object Data { get; private set; }
    }
}
