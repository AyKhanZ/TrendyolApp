using System.Collections.Generic;
using TrendyolApp.Model;
namespace TrendyolApp.Message;
public class UsersMessage
{
    public Dictionary<string, User>? UsersDictAdmin { get; set; } = new(); 
}
    
