using Lukomor.Domain.Features;
using WKosArch.UI_Service;

public interface IUIService : IFeature
{
    UserInterface UI { get; }
}