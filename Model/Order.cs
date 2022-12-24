using System; 
namespace TrendyolApp.Model;
public class Order
{
    //Place order
    public string? Size { get; set; } = "M";
    public string? Color { get; set; } = "Black";
    public string? Quantity { get; set; }
    public string? Price { get; set; }
    public string? ShopDeliveryPrice { get; set; }
    public string? Link { get; set; }
    public string? Notes { get; set; }
      
    //Declare
    public string? ProductCategory { get; set; }
    public string? TrackingNumber { get; set; }
    public string? Currency { get; set; } = "TRY";
    public Uri? Invoice { get; set; } 
    public bool ContainsLiquid { get; set; }
    public StatusOfOrders? Status { get; set; } = new();
}
