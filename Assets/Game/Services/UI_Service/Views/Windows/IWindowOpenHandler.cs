using Lukomor.Common;
namespace WKosArch.UI_Service.Views.Windows
{
    public interface IWindowOpenHandler
    {
        WindowViewModel OpeningWindowViewModel { get; }
        IWindow OpeningWindow { get; }
        IWindowOpenHandler AddPayloads(params Payload[] payloads);
        void WithBackDestination<TWindowViewModel>() where TWindowViewModel : WindowViewModel;
    }
}