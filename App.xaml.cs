using TrendyolApp.Services.Interfaces;
using TrendyolApp.View;
using TrendyolApp.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;
using System.Windows;
using TrendyolApp.Services.Classes;
using TrendyolApp.Message;

namespace TrendyolApp;
public partial class App : Application
{
    public static Container? Container { get; internal set; }
    protected override void OnStartup(StartupEventArgs e)
    {
        Register();

        MainStartup();

        base.OnStartup(e);
    }

    private void Register()
    {
        Container = new();

        Container.RegisterSingleton<IMessenger, Messenger>(); 
        Container.RegisterSingleton<INavigationService, NavigationService>();

        Container.RegisterSingleton<MainViewModel>();
        Container.RegisterSingleton<LoginViewModel>();
        Container.RegisterSingleton<RegistrationViewModel>();
        Container.RegisterSingleton<FirstViewModel>();
        Container.RegisterSingleton<UserSettingsViewModel>();
        Container.RegisterSingleton<PlaceOrderViewModel>();
        Container.RegisterSingleton<DeclareViewModel>();
        Container.RegisterSingleton<BalanceViewModel>();
        Container.RegisterSingleton<AdminViewModel>();

        Container.Verify();
    }

    private void MainStartup()
    {
        Window mainView = new MainView();

        mainView.DataContext = Container?.GetInstance<MainViewModel>();

        mainView.ShowDialog();
    }
}
