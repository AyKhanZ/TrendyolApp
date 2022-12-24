using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command; 
using TrendyolApp.Services.Interfaces;
using TrendyolApp.Model;
using GalaSoft.MvvmLight.Messaging;
using TrendyolApp.Message; 
using TrendyolApp.Services.Classes;
using System.Collections.Generic;
namespace TrendyolApp.ViewModel;
public class FirstViewModel : ViewModelBase
{
    public string? user_info { get; set; } = " ";
    public User? user { get; set; } = new();
    public TabsObservableCollection? TabsList { get; set; } = new(); 
    private readonly INavigationService? _navigationService;
    private readonly IMessenger _messenger; 
    public FirstViewModel(INavigationService navigationService, IMessenger messenger)
    {
        _navigationService = navigationService;
        _messenger = messenger;
        _messenger.Register<ParameterMessage>(this, param =>
        {
            user = param?.Message as User;
            user_info = user?.UserName;
            TabsList = new();
            TabsList = TabsService.SortByTabs(user,TabsList);
        });
    }
    public RelayCommand Settings
    {
        get => new(() =>
        {
            _navigationService?.NavigateTo<UserSettingsViewModel>(new ParameterMessage { Message = Users.UsersDict![user_info!] });
        });
    }
    public RelayCommand PlaceOrder
    {
        get => new(() =>
        {
            _navigationService?.NavigateTo<PlaceOrderViewModel>(new ParameterMessage { Message = Users.UsersDict![user_info!] });
        });
    }
    public RelayCommand Declare
    {
        get => new(() =>
        {
            _navigationService?.NavigateTo<DeclareViewModel>(new ParameterMessage { Message = Users.UsersDict![user_info!] });
        });
    }
    public RelayCommand GoToBalanceView
    {
        get => new(() =>
        {
            _navigationService?.NavigateTo<BalanceViewModel>(new ParameterMessage { Message = Users.UsersDict![user_info!] });
        });
    }
    public RelayCommand ExitToLogin
    {
        get => new(() =>
        {
            var json = SerialiazibleService<Dictionary<string, User>>.Serialization(Users.UsersDict!);
            FileService.SaveData(json, "SerializeJSONAykhan.json");

            _navigationService?.NavigateTo<LoginViewModel>(new ParameterMessage() { Message = Users.UsersDict![user_info!] });
        });
    }
}
