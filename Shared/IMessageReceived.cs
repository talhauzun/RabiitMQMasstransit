using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IMessageReceived
    { 
        string OrderId { get; }
        DateTime OrderDate { get; }
    }

}
