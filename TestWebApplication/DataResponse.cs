namespace TestWebApplication
{
    public class DataResponse<T> : IDataResponse<T>
    {
        readonly T data;

        public DataResponse(T data)
        {
            this.data = data;
        }

        public T GetData()
        {
            return this.data;
        }
    }
}
