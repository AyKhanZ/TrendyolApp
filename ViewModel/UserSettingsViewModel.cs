using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command; 
using System.Windows; 
using TrendyolApp.Services.Interfaces;
using TrendyolApp.Model;
using GalaSoft.MvvmLight.Messaging;
using TrendyolApp.Message;
using System.Windows.Controls;

namespace TrendyolApp.ViewModel;
public class UserSettingsViewModel : ViewModelBase
{
    public string? user_info { get; set; } = " ";
    public User? user { get; set; } = new();

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
            if (!string.IsNullOrWhiteSpace(user?.Address)
            && !string.IsNullOrWhiteSpace(user.UserName)
            && !string.IsNullOrWhiteSpace(user?.Password) 
            && !string.IsNullOrWhiteSpace(user?.Serial)
            && !string.IsNullOrWhiteSpace(user?.Phone)
            && !string.IsNullOrWhiteSpace(user?.Fin))
            {
                Users.UsersDict.Remove(user_info); 
                user_info = user.UserName;
                MessageBox.Show(Users.UsersDict.TryAdd(user_info, user).ToString());
                //Users.UsersDict.Add(user_info, user);

                //Users.UsersDict[user_info].Address = user.Address;
                //Users.UsersDict[user_info].Serial = user.Serial;
                //Users.UsersDict[user_info].Phone = user.Phone;
                //Users.UsersDict[user_info].Fin = user.Fin;
                _navigationService?.NavigateTo<FirstViewModel>(new ParameterMessage { Message = Users.UsersDict[user_info] });
            }
            else MessageBox.Show("All rows should be completed!");
        });
    }
    public RelayCommand BackToFirst
    {
        get => new(() =>
        {
            _navigationService?.NavigateTo<FirstViewModel>(new ParameterMessage { Message = Users.UsersDict[user_info] });
        });
    }
}
