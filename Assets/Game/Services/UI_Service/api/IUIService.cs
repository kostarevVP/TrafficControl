using System;
using WKosArch.Domain.Features;
using WKosArch.UIService;

namespace WKosArch.Services.UIService
{
    public interface IUIService : IFeature
    {
        UserInterface UI { get; }
    }
}