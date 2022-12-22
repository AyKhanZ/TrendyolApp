using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using TrendyolApp.Message;
using TrendyolApp.Services.Interfaces;
namespace TrendyolApp.Services.Classes;
internal class NavigationService : INavigationService
{
    private readonly IMessenger _messenger; 
    public NavigationService(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void NavigateTo<T>(ParameterMessage? message) where T : ViewModelBase
    {
        _messenger.Send(message);
        _messenger.Send(new NavigationMessage() { ViewModelType = typeof(T) });
    }    
    public void NavigateTo<T>(UsersMessage? message) where T : ViewModelBase
    {
        _messenger.Send(message);
        _messenger.Send(new NavigationMessage() { ViewModelType = typeof(T) });
    }
}