using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using GoGo.Product.Application.Shared.Abstraction;

namespace GoGo.Product.Infastructure.ServiceBus
{
    public class ServiceBusDispatcher : IServiceBusDispatcher
    {
        private readonly ServiceBusClient _serviceBusClient;
        public ServiceBusDispatcher(ServiceBusClient serviceBusClient)
        {
            _serviceBusClient = serviceBusClient;
        }

        public Task SendAsync<T>(T message) where T : BusEvent
        {
            var busSender = _serviceBusClient.CreateSender(message.TopicName);
            return busSender.SendMessageAsync(new ServiceBusMessage(JsonConvert.SerializeObject(new { Message = message })));
        }
    }
}