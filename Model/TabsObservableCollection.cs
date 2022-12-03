using System.Collections.ObjectModel; 
namespace TrendyolApp.Model;
public class TabsObservableCollection
{
    public ObservableCollection<Order> OrdersInFillial { get; set; } = new();
    public ObservableCollection<Order> OrdersInShipped { get; set; } = new();
    public ObservableCollection<Order> OrdersInAbroadWarehouse { get; set; } = new();
    public ObservableCollection<Order> AllPackages { get; set; } = new();
}