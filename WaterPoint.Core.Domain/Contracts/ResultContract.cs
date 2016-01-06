

namespace WaterPoint.Core.Domain.Contracts
{
    public class CommandResult
    {
        private const string Success = "success";
        private const string Failed = "failed";

        public object Data { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }

        public CommandResult(object data, bool success)
        {
            Data = data;
            Status = (success ? Success : Failed);
            Message = !success
                ? "operation is finished but there is no result returned"
                : "operation is finished with no errors.";
        }
    }
}
