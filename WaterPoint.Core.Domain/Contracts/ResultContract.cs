

namespace WaterPoint.Core.Domain.Contracts
{
    public class CommandResult
    {
        private const string Success = "success";
        private const string Failed = "failed";

        public object Data { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }

        public CommandResult(object data, string target, bool success)
        {
            Data = data;
            Status = (success ? Success : Failed);
            Message = !success
                ? $"{target} {data ?? string.Empty}: operation is finished but there is no result returned"
                : $"{target} {data ?? string.Empty}: operation is finished with no errors.";
        }
    }
}
