using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using TrendyolApp.Message;
using TrendyolApp.Model;
using TrendyolApp.Services.Interfaces;
 

namespace TrendyolApp.ViewModel;
public class AdminViewModel : ViewModelBase
{
    //Список для того чтобы выбрать один из всего листа и изменять 
    public Order? UserOrder { get; set; } = new();
    //Список всех покупок
    public ObservableCollection<Order>? UsersOrdersList { get; set; }
    //Для отображения логинов всех пользователей в списке
    public ObservableCollection<User>? ListOfUsersForSharing { get; set; } = new(Users.UsersDict.Values);
    //Статус одного конкретного товара который выделил юзер
    public StatusOfOrders? Status { get; set; } = new();
    public string? Search { get; set; } = "";
    private readonly INavigationService? _navigationService;

    public AdminViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }
    public RelayCommand SearchCommand
    {
        get => new(() =>
        {
            if (Users.UsersDict!.ContainsKey(Search))
            {
                UsersOrdersList = Users.UsersDict[Search].Orders;
            }
        });
    }
    public RelayCommand BackToLogin
    {
        get => new(() =>
        {
            _navigationService?.NavigateTo<LoginViewModel>();
        });
    }
    public RelayCommand Delete
    {
        get => new(() =>
        {
            UsersOrdersList?.Remove(UserOrder!);
        });
    }
    public RelayCommand DeleteAll
    {
        get => new(() =>
        {
            UsersOrdersList?.Clear();
        });
    }       
    public RelayCommand RadioBtnCommand
    {
        get => new(() =>
        {
            UserOrder!.Status = Status;
            UsersOrdersList = Users.UsersDict![Search!].Orders; 
        });
    }    
}
 