namespace WaterPoint.Core.Domain.Contracts
{
    public class ResultContract<T>
    {
        public T Data { get; set; }

        public void SetData(T obj)
        {
            Data = obj;
        }

        public ResultContract(T obj)
        {
            Data = obj;
        }
    }
}
