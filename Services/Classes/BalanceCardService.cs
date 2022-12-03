using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyolApp.Services.Classes;
public class BalanceCardService
{
    public string? NameBankCard { get; set; }
    public string? HexCode { get; set; }
    public string? Cvv { get; set; }
    public string? ValidThru { get; set; }
    public float Balance { get; set; } 
}
