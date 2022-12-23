using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using TrendyolApp.Message;
using TrendyolApp.Model;
using TrendyolApp.Services.Classes;
using TrendyolApp.Services.Interfaces;
namespace TrendyolApp.ViewModel;
public class AdminViewModel : ViewModelBase
{
    
    //Список для того чтобы выбрать один из всего листа и изменять 
    public Order? UserOrder { get; set; } = new();
    //Список всех покупок
    public ObservableCollection<Order>? UsersOrdersList { get; set; }
    //Для отображения логинов всех пользователей в списке
    public ObservableCollection<User>? ListOfUsersForSharing { get; set; } = new();
    //Статус одного конкретного товара который выделил юзер
    public StatusOfOrders? Status { get; set; } = new();
    public User? user { get; set; } = new();
    private readonly INavigationService? _navigationService; 
    private readonly IMessenger? _messenger;
    public AdminViewModel(INavigationService? navigationService,IMessenger messenger)
    {
        ListOfUsersForSharing = new();
        //json 
        var json = FileService.ReadData("SerializeJSONAykhan.json");
        if (json != null) Users.UsersDict = SerialiazibleService<Dictionary<string, User>>.Deserialization(json);

        _navigationService = navigationService;
        _messenger = messenger; 
         
        _messenger.Register<UsersMessage>(this, param => {
            foreach (var item in param?.UsersDictAdmin!.Values!)
            {
                ListOfUsersForSharing!.Add(item);
            }
        });
    }
    public RelayCommand SearchCommand
    {
        get => new(() =>
        { 
            if (Users.UsersDict!.ContainsKey(user?.UserName!)) UsersOrdersList = user?.Orders; 
             
        });
    }
    public RelayCommand BackToLogin
    {
        get => new(() =>
        {
            //Json
            var json = SerialiazibleService<Dictionary<string, User>>.Serialization(Users.UsersDict!);
            FileService.SaveData(json, "SerializeJSONAykhan.json");
            _navigationService?.NavigateTo<LoginViewModel>(new UsersMessage() { UsersDictAdmin = Users.UsersDict});
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
            UsersOrdersList = Users.UsersDict![user!.UserName!].Orders; 
        });
    }    
}
 