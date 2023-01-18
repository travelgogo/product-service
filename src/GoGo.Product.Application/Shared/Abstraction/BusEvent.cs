using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoGo.Product.Application.Shared.Abstraction
{
    public abstract class BusEvent
    {
        public abstract string TopicName { get; set; }
    }
}