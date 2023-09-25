using Lukomor.Common;
using WKosArch.UI_Service.Common;

namespace WKosArch.UI_Service.Views.Windows
{
    public class WindowOpenHandler : IWindowOpenHandler
    {
        public WindowViewModel OpeningWindowViewModel { get; }
        public IWindow OpeningWindow => OpeningWindowViewModel.Window;

        private UserInterface _ui;
        
        public WindowOpenHandler(WindowViewModel windowViewModel, UserInterface ui)
        {
            OpeningWindowViewModel = windowViewModel;
            _ui = ui;
        }

        public IWindowOpenHandler AddPayloads(params Payload[] payloads)
        {
            OpeningWindowViewModel.AddPayloads(payloads);

            return this;
        }

        public void WithBackDestination<TWindowViewModel>() where TWindowViewModel : WindowViewModel
        {
            _ui.SetBackDestination<TWindowViewModel>();
        }
    }
}