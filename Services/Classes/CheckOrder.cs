using System; 
using System.Windows;
using TrendyolApp.Model;
namespace TrendyolApp.Services.Classes;
public static class CheckOrder
{
    public static bool CheckDeclareOrder(Order? order, string? user_info)
    { 
        if (!string.IsNullOrWhiteSpace(order?.Price) && !string.IsNullOrWhiteSpace(order?.Quantity) && !string.IsNullOrWhiteSpace(order?.SiteName) 
            && !string.IsNullOrWhiteSpace(order?.ProductCategory) && !string.IsNullOrWhiteSpace(order?.TrackingNumber))
        {
            if (Convert.ToInt32(order.Price) <= 0) { MessageBox.Show("Price should be more than 0!"); return false; }
            else
            {
                if (Convert.ToInt32(order.Quantity) <= 0) { MessageBox.Show("Quality should be more than 0!"); return false; }
                else
                {
                    if (Users.UsersDict![user_info]!.Balance - Convert.ToInt32(order?.Price) * Convert.ToInt32(order.Quantity) >= 0)
                    {  
                        return true;
                    }
                    else { MessageBox.Show("You have no enought money on your balance!"); return false; }
                }
            }
        }
        else { MessageBox.Show("Link,size,color,price rows are requared!"); return false; }
    }
    public static bool CheckPlaceOrder(Order? order, string? user_info)
    {
        if (!string.IsNullOrWhiteSpace(order?.Link) && !string.IsNullOrWhiteSpace(order?.Size) && !string.IsNullOrWhiteSpace(order?.Color)
            && !string.IsNullOrWhiteSpace(order?.Quantity) && !string.IsNullOrWhiteSpace(order?.Price) && !string.IsNullOrWhiteSpace(order?.ShopDeliveryPrice))
        {
            if (Convert.ToInt32(order.Price) <= 0 && Convert.ToInt32(order.ShopDeliveryPrice) <= 0) {MessageBox.Show("Price should be more than 0!");return false;}
            else
            {
                if (Convert.ToInt32(order.Quantity) <= 0) {MessageBox.Show("Quality should be more than 0!");return false;}
                else
                {
                    if (Users.UsersDict![user_info]!.Balance - Convert.ToInt32(order?.Price) * Convert.ToInt32(order?.Quantity) - Convert.ToInt32(order?.ShopDeliveryPrice) * Convert.ToInt32(order?.Quantity) >= 0)
                    { 
                        return true;
                    }
                    else {MessageBox.Show("You have no enought money on your balance!");return false;}
                }
            }
        }
        else {MessageBox.Show("Link,size,color,quantity,price,shop delivery price rows have to be completed");return false; }
    }
}
    