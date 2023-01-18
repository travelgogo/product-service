namespace GoGo.Product.Application.Shared.Abstraction
{
    public interface IServiceBusDispatcher
    {
        Task SendAsync<T> (T message) where T : BusEvent;
    }
}