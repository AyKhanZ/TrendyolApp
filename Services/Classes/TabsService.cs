using TrendyolApp.Model;
namespace TrendyolApp.Services.Classes;
static public class TabsService
{ 
    static public TabsObservableCollection SortByTabs(User? user,TabsObservableCollection? listOfTabs)
    {
        if (user != null)
        {
            foreach (var item in user?.Orders!)
            {
                if (!listOfTabs.OrdersInFillial.Contains(item) && item!.Status!.InFillial!)
                {
                    listOfTabs.OrdersInFillial.Add(item);
                }
                else if (!listOfTabs.OrdersInShipped.Contains(item) && item!.Status!.Shipped!)
                {
                    listOfTabs.OrdersInShipped.Add(item); 
                }
                else if (!listOfTabs.OrdersInAbroadWarehouse.Contains(item) && item!.Status!.InAbroadwarehouse!)
                {
                    listOfTabs.OrdersInAbroadWarehouse.Add(item);
                }
                if (!listOfTabs.AllPackages.Contains(item))
                {
                    listOfTabs.AllPackages.Add(item);
                }
            }
        }
        return listOfTabs;
    }
}
