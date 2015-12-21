namespace WaterPoint.Core.Domain
{
    public interface IRequest
    {
    }

    public interface IRequestProcessor<in TInput, out TOutput>
        where TInput : IRequest
    {
        TOutput Process(TInput input);
    }
}
