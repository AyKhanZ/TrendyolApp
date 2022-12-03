using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolApp.Message;

namespace TrendyolApp.Model
{
    public class User:ISendable
    {
        public float Balance { get; set; }
        public string? UserName { get; set; }
        public string? Serial { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Fin { get; set; }
        public string? Password { get; set; }

        public ObservableCollection<Order>? Orders { get; set; } = new();
    }
}
