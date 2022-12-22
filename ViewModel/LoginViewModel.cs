using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command; 
using System.Collections.Generic; 
using System.Windows; 
using TrendyolApp.Services.Interfaces;
using TrendyolApp.Model;
using GalaSoft.MvvmLight.Messaging;
using TrendyolApp.Message;
using System.Windows.Controls;
using TrendyolApp.Services.Classes;
using System.Collections.ObjectModel;

namespace TrendyolApp.ViewModel;
public class LoginViewModel : ViewModelBase
{
    public Dictionary<string, string> LoginDict { get; set; } = new Dictionary<string, string>();
    public string? user_info { get; set; } = "";
    private readonly INavigationService? _navigationService;
    private readonly IMessenger? _messenger; 


    public LoginViewModel(INavigationService navigationService, IMessenger messenger )
    {
        var json = FileService.ReadData("SerializeJSONAykhan.json");
        if (json != null) Users.UsersDict = SerialiazibleService<Dictionary<string, User>>.Deserialization(json);

        _navigationService = navigationService;
        _messenger = messenger; 
         
        _messenger.Register<ParameterMessage>(this, param =>
        {
            var User = param?.Message as User;
            user_info = User?.UserName;
        });        
    }
    public RelayCommand RegistrationCommand
    {
        get => new(() =>
        {
            _navigationService?.NavigateTo<RegistrationViewModel>(new UsersMessage() { UsersDictAdmin = Users.UsersDict}) ;
        });
    }
    public RelayCommand<PasswordBox> LoginCommand
    {
        get => new((pass) =>
        {
            if (Users.UsersDict!.ContainsKey(user_info!))
            {
                if (Users.UsersDict[user_info!].Password == pass.Password)
                {
                    _navigationService?.NavigateTo<FirstViewModel>(new ParameterMessage { Message = Users.UsersDict[user_info!] });
                }
                else MessageBox.Show("Incorrect password!");
            }
            else if (user_info == "admin" && pass.Password == "admin")
            {
                _navigationService?.NavigateTo<AdminViewModel>(new UsersMessage { UsersDictAdmin = Users.UsersDict });
            }
            else MessageBox.Show("You aren\'t a user!");
        });
    }
}
