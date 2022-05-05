namespace Ambev.Poc.Dev.Domain.Models.Response
{
    public class ResponseBaseModel<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }


        public ResponseBaseModel<T> Ok(T data)
        {
            Success = true;
            Data = data;

            return this;
        }

        public ResponseBaseModel<T> NotFound()
        {
            Success = false;
            Message = "Resource not found";
            return this;
        }

        public void BadRequest()
        {
            Success = false;
            Message = "Request error";
        }
    }
}
