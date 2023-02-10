using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoGo.Product.Function.Helpers.BlobStorage
{
    public class BlobStorageOptions
    {
        public string DefaultEndpointsProtocol { get; set; } = "https";
        public string AccountName { get; set; }
        public string AccountKey { get; set; }
        public string EndpointSuffix { get; set; }
        public string DefaultContainer { get; set; }
    }
}