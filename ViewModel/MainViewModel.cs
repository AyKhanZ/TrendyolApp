using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging; 
using System.Collections.Generic; 
using System.Windows;
using TrendyolApp.Message;
using TrendyolApp.Model;
using TrendyolApp.Services.Classes;
namespace TrendyolApp.ViewModel;
public class MainViewModel : ViewModelBase
{ 
    public ViewModelBase? CurrentViewModel { get; set; }
    private readonly IMessenger _messenger; 
    public MainViewModel(IMessenger messenger)
    {
        CurrentViewModel = App.Container?.GetInstance<LoginViewModel>();

        _messenger = messenger; 

        _messenger.Register<NavigationMessage?>(this, message =>
        {
            var viewModel = App.Container?.GetInstance(message?.ViewModelType!) as ViewModelBase;
            CurrentViewModel = viewModel;
        });
    }
    public RelayCommand ExitCommand
    {
        get => new(() =>
        {
            //json
            var json = SerialiazibleService<Dictionary<string, User>>.Serialization(Users.UsersDict!);
            FileService.SaveData(json, "SerializeJSONAykhan.json");
            App.Current.Shutdown();
        });
    }
    public WindowState State { get; set; }
    public RelayCommand MinimalizeCommand
    {
        get => new(() =>
        {
            State = WindowState.Minimized;
        });
    }
}