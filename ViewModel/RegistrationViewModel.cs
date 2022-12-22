using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command; 
using TrendyolApp.Message;
using TrendyolApp.Services.Interfaces; 
using System.Collections.Generic; 
using TrendyolApp.Model; 
using System.Windows; 
using System.Windows.Controls; 
using TrendyolApp.Services.Classes;
namespace TrendyolApp.ViewModel;
public class RegistrationViewModel : ViewModelBase
{
    public User? user { get; set; } 
    public string? ConfirmPassword { get; set; }
    private readonly INavigationService? _navigationService;
    public RegistrationViewModel(INavigationService navigationService)
    {
        user = new();
        _navigationService = navigationService;
        var json = FileService.ReadData("SerializeJSONAykhan.json");
        if (json != null) Users.UsersDict = SerialiazibleService<Dictionary<string, User>>.Deserialization(json);
    }
    public RelayCommand<PasswordBox> Registration
    {
        get => new(param =>
        {
            user!.Password = param.Password;
            var a = CheckRegistration.CheckUser(user, ConfirmPassword);
            if (a == null)
            {
                //Json
                var json = SerialiazibleService<Dictionary<string, User>>.Serialization(Users.UsersDict!);
                FileService.SaveData(json, "SerializeJSONAykhan.json"); 

                _navigationService?.NavigateTo<LoginViewModel>(new ParameterMessage() { Message = user });
                user = new();
            }
            else MessageBox.Show(a);
        });
    }
    public RelayCommand BackToLoginCommand
    {
        get => new(() =>
        {
            _navigationService?.NavigateTo<LoginViewModel>(new ParameterMessage(){ Message = user});
        });
    }
}
