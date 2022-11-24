namespace Tiangler.Core.ResultModels
{
    public class CommandResult<T> : ICommandResult<T>
    {
        public T Result { get; private set; }
        public bool IsSuccessful => Error == null && !Errors.Any();
        public (string Code, string Message)? Error { get; private set; }
        public List<(string Code, string Message)?> Errors { get; private set; }

        public CommandResult(T terms)
        {
            Result = terms;
            Errors = new List<(string Code, string Message)?>();
        }

        public CommandResult(string errorCode, string errorMessage)
        {
            Error = (errorCode ?? "ErrorCode missing", errorMessage ?? "Error message missing");
        }

        public CommandResult(List<(string Code, string Message)?> error)
        {
            Errors = new List<(string Code, string Message)?>();
            Errors.AddRange(error);
        }

        public CommandResult(string code, string[] errors)
        {
            var collection = new List<(string Code, string Message)?>();
            foreach (var item in errors)
            {
                collection.Add((code, item));
            }

            Errors = collection;
        }

        public CommandResult(string errorCode, string errorMessage, T result)
        {
            Error = (errorCode ?? "ErrorCode missing", errorMessage ?? "Error message missing");


            Error = (errorCode, errorMessage);
            Result = result;
        }

        public CommandResult((string Code, string Message) errorCode)
        {
            Error = errorCode;
        }
    }
}
