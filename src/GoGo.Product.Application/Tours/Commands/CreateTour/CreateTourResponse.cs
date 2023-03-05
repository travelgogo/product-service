using GoGo.Product.Application.Models;

namespace GoGo.Product.Application.Tours.Commands.CreateTour
{
    public class CreateTourResponse : ResponseBase
    {
        public CreateTourResponse(bool isSuccess, string message, int httpStatusCode) 
            : base(isSuccess, message, httpStatusCode)
        {

        }
    }
}