

namespace WaterPoint.Core.Domain.Contracts
{
    public class CommandResult
    {
        private const string DefaultFailed = "operation is finished but there is no result returned";
        private const string DefaultSuccess = "operation is finished with no errors.";

        public object Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public CommandResult(object data, bool success)
        {
            Data = data;
            IsSuccess = success;
            Message = !success ? DefaultFailed : DefaultSuccess;
        }
    }

    public class IdCommandResult : CommandResult
    {
        public IdCommandResult(int id, bool success)
            : base(id, success)
        {
            if (success)
                Data = new { id };
        }
    }

    public class ObjectsCountCommandResult : CommandResult
    {
        public ObjectsCountCommandResult(int rowsAffected, bool success)
            : base(rowsAffected, success)
        {
            Data = new { objectsUpdated = rowsAffected };
        }
    }
}
