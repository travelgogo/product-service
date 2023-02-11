using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace GoGo.Product.Function.ServiceBus
{
    public class TourIngestion
    {
        [FunctionName("ProcessTourImages")]
        public async Task ProcessTourImages([ServiceBusTrigger("pds.tour.created", "process-images", Connection ="ServiceBusListen")] string input)
        {
            var tmp = input;
            await Task.Yield();
        }
    }
}