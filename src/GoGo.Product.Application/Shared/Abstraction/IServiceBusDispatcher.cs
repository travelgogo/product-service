namespace GoGo.Product.Application.Shared.Abstraction
{
    public interface IServiceBusDispatcher
    {
        Task SendAsync<T> (string topicName, T message);
    }
}