namespace GoGo.Product.Application.Models
{
    public class ResponseBase
    {
        public ResponseBase(){}
        public ResponseBase(bool isSuccess, string message, int httpStatusCode)
        {
            IsSuccess = isSuccess;
            Message = message;
            HttpStatusCode = httpStatusCode;
        }
        public bool IsSuccess { get; set; } = true;
        public string? Message { get; set; }
        public int HttpStatusCode {get; set;}
        public virtual object? Data { get; set; }
    }
}