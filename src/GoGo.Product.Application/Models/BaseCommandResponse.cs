using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoGo.Product.Application.Models
{
    public class BaseCommandResponse
    {
        public BaseCommandResponse(bool isSuccess, string message, int httpStatusCode)
        {
            IsSuccess = isSuccess;
            Message = message;
            HttpStatusCode = httpStatusCode;
        }
        public bool IsSuccess { get; set; } = true;
        public string? Message { get; set; }
        public int HttpStatusCode {get; set;}
        
    }
}