using GalaSoft.MvvmLight;
using TrendyolApp.Message;
namespace TrendyolApp.Services.Interfaces;
public interface INavigationService
{
    public void NavigateTo<T>(ParameterMessage message = null) where T : ViewModelBase;
}