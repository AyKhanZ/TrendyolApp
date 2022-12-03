using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command; 
using System.Windows; 
using TrendyolApp.Services.Interfaces;
using TrendyolApp.Model;
using GalaSoft.MvvmLight.Messaging;
using TrendyolApp.Message; 
using TrendyolApp.Services.Classes;

namespace TrendyolApp.ViewModel;
public class BalanceViewModel : ViewModelBase
{
    public string? user_info { get; set; } = "";
    public User? user { get; set; }
    public BalanceCardService? Card { get; set; } = new();
    private readonly INavigationService? _navigationService;
    private readonly IMessenger _messenger;
    public BalanceViewModel(INavigationService navigationService, IMessenger messenger)
    {
        _navigationService = navigationService;
        _messenger = messenger;
        _messenger.Register<ParameterMessage>(this, param =>
        {
            var User = param?.Message as User;
            user_info = User?.UserName;
        });
    }
    public RelayCommand AddMoney
    {
        get => new(() =>
        {
            if (!string.IsNullOrWhiteSpace(Card.NameBankCard)
            && !string.IsNullOrWhiteSpace(Card.HexCode)
            && !string.IsNullOrWhiteSpace(Card.Cvv)
            && !string.IsNullOrWhiteSpace(Card.ValidThru))
            {
                Users.UsersDict[user_info].Balance += Card.Balance;
                _navigationService?.NavigateTo<FirstViewModel>(new ParameterMessage { Message = Users.UsersDict[user_info] });
            }
            else MessageBox.Show("All rows are requared!");
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