using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command; 
using System.Windows; 
using TrendyolApp.Services.Interfaces;
using TrendyolApp.Model;
using GalaSoft.MvvmLight.Messaging;
using TrendyolApp.Message;
using System.Windows.Controls;
using TrendyolApp.Services.Classes;
using System.Collections.Generic;
namespace TrendyolApp.ViewModel;
public class UserSettingsViewModel : ViewModelBase
{
    public string? user_info { get; set; } = " ";
    public User? user { get; set; } = new();
    public string? ConfirmPassword { set; get; }
    private readonly INavigationService? _navigationService;
    private readonly IMessenger? _messenger;
    public UserSettingsViewModel(INavigationService navigationService, IMessenger messenger)
    {
        _navigationService = navigationService;
        _messenger = messenger;
        _messenger.Register<ParameterMessage>(this, param =>
        {
            var User = param?.Message as User;
            user_info = User?.UserName;
        });
    }
    public RelayCommand<PasswordBox> Save
    {
        get => new(param =>
        { 
            user!.Password = param?.Password;
            user!.Orders = Users.UsersDict![user_info!].Orders;
            var a = CheckRegistration.CheckUser(user, ConfirmPassword);
            if(a == null) { 
                Users.UsersDict?.Remove(user_info!); 
                user_info = user.UserName;
                var flag = Users.UsersDict?.TryAdd(user_info!, user).ToString();

                var json = SerialiazibleService<Dictionary<string, User>>.Serialization(Users.UsersDict!);
                FileService.SaveData(json, "SerializeJSONAykhan.json");
                
                _navigationService?.NavigateTo<FirstViewModel>(new ParameterMessage { Message = Users.UsersDict?[user_info!] });
            }
            else MessageBox.Show(a);
        });
    }
    public RelayCommand BackToFirst
    {
        get => new(() =>
        {
            _navigationService?.NavigateTo<FirstViewModel>(new ParameterMessage { Message = Users.UsersDict?[user_info!] });
        });
    }
}
