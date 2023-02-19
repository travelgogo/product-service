using GoGo.Infrastructure.ServiceBus;
namespace GoGo.Product.Application.Tours.Commands.CreateTour
{
    public class CreateTourEvent : CreateTourRequest
    {
        public int Id { get; set; }
    }
}