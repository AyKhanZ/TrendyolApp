using TrendyolApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TrendyolApp.Message;

namespace TrendyolApp.Message
{
    public class ParameterMessage
    {
        public ISendable? Message { get; set; }
    }
}
