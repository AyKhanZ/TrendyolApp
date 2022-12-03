using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;  
using System.Windows.Media.Imaging;
using TrendyolApp.Services.Interfaces;
using TrendyolApp.Model;
using GalaSoft.MvvmLight.Messaging;
using TrendyolApp.Message;  
using Microsoft.Win32;
using TrendyolApp.Services.Classes; 
namespace TrendyolApp.ViewModel;
public class DeclareViewModel : ViewModelBase
{
    public string? user_info { get; set; } = "";
    public BitmapImage? image { get; set; }
    public Order? order { get; set; } = new();
    private readonly INavigationService? _navigationService;
    private readonly IMessenger _messenger;
    public DeclareViewModel(INavigationService navigationService, IMessenger messenger)
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
            order.Color = "Black";
            order.Size = "M";
            if (CheckOrder.CheckDeclareOrder(order, user_info))
            {
                Users.UsersDict![user_info]!.Balance -= Convert.ToInt32(order?.Price) * Convert.ToInt32(order?.Quantity);
                Users.UsersDict![user_info]!.Balance -= Convert.ToInt32(order?.ShopDeliveryPrice) * Convert.ToInt32(order?.Quantity);

                Users.UsersDict[user_info]?.Orders?.Add(order);
                order = new();
                _navigationService?.NavigateTo<FirstViewModel>(new ParameterMessage { Message = Users.UsersDict[user_info] });
            }
        });
    }
    public RelayCommand ImageDownoload => new(() =>
    {
        OpenFileDialog openImage = new();
        openImage.Filter = "Image files(*.PNG, *.JPG, *.BMP)|*.png;*.jpg;*.bmp";
        if (openImage.ShowDialog() == true)
        {
            order.Invoice = new Uri(openImage.FileName);
            image = new(order.Invoice);
        }
    });
    public RelayCommand BackToFirst
    {
        get => new(() =>
        {
            _navigationService?.NavigateTo<FirstViewModel>(new ParameterMessage { Message = Users.UsersDict[user_info] });
        });
    }
}
