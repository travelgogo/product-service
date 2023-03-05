using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.Documents.Client;
using GoGo.Infrastructure.Repository;

namespace GoGo.Product.Function.ServiceBus
{
    public class TourIngestion
    {
        private readonly IUnitOfWork _unitOfWork;
        public TourIngestion(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [FunctionName("CreateTourDocument")]
        public async Task CreateTourDocument([ServiceBusTrigger("pds.tour.created", "create-tour-document", Connection ="ServiceBusListen")] string input,
            [CosmosDB(Connection = "CosmosDb")] DocumentClient documentClient)
        {
            var tmp = input;
            await Task.Yield();
        }
    }
}