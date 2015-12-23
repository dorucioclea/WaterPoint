using WaterPoint.Core.Domain.Dtos;

namespace WaterPoint.Core.Domain.Contracts
{
    public class CommandResultContract : IContract
    {
        public const string Success = "success";
        public const string Failed = "failed";

        public object Data { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
