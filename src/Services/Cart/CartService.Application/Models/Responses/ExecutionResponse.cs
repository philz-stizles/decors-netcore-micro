namespace Cart.Application.Models.Responses
{
    public class BaseResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }

    public class DBResponse<T> : BaseResponse
    {
        public T Data { get; set; }
    }

    public class ExecutionResponse<T> : BaseResponse
    {
        public T Data { get; set; }
    }

    public class ServiceResponse<T> : BaseResponse
    {
        public T Data { get; set; }
    }

    public class ApiResponse<T> : BaseResponse
    {
        public T Data { get; set; }
    }
}
