﻿using WKosArch.Common;
namespace WKosArch.UIService.Views.Windows
{
    public interface IWindowOpenHandler
    {
        WindowViewModel OpeningWindowViewModel { get; }
        IWindow OpeningWindow { get; }
        IWindowOpenHandler AddPayloads(params Payload[] payloads);
        void WithBackDestination<TWindowViewModel>() where TWindowViewModel : WindowViewModel;
    }
}