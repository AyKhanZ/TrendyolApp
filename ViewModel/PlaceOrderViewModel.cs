using GalaSoft.MvvmLight; 
using GalaSoft.MvvmLight.Command; 
using System.Windows; 
using TrendyolApp.Services.Interfaces;
using TrendyolApp.Model;
using GalaSoft.MvvmLight.Messaging;
using TrendyolApp.Message;
using System;
using TrendyolApp.Services.Classes;
using System.Collections.Generic;
namespace TrendyolApp.ViewModel;
public class PlaceOrderViewModel : ViewModelBase
{
    public string? user_info { get; set; } = "";
    public Order? order { get; set; } = new();
    private readonly INavigationService? _navigationService;
    private readonly IMessenger _messenger;
    public PlaceOrderViewModel(INavigationService navigationService, IMessenger messenger)
    {
        _navigationService = navigationService;
        _messenger = messenger;
        _messenger.Register<ParameterMessage>(this, param =>
        {
            var User = param?.Message as User;
            user_info = User?.UserName;
        });
    }
    public RelayCommand Save
    {
        get => new(() =>
        {
            if (CheckOrder.CheckPlaceOrder(order, user_info))
            {
                Users.UsersDict![user_info!]!.Balance -= Convert.ToInt32(order?.Price);
                Users.UsersDict![user_info!]?.Orders?.Add(order!);
                order = new();

                //Json
                var json = SerialiazibleService<Dictionary<string, User>>.Serialization(Users.UsersDict!);
                FileService.SaveData(json, "SerializeJSONAykhan.json"); 

                _navigationService?.NavigateTo<FirstViewModel>(new ParameterMessage { Message = Users.UsersDict[user_info!] });
            }
        });
    }
    public RelayCommand BackToFirst
    {
        get => new(() =>
        {
            _navigationService?.NavigateTo<FirstViewModel>(new ParameterMessage { Message = Users.UsersDict![user_info!] });
        });
    }
}
