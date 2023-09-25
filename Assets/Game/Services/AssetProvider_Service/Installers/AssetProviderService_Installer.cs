using Lukomor.Common.DIContainer;
using Lukomor.Domain.Contexts;
using Lukomor.Domain.Features;
using Lukomor.Extentions;
using UnityEngine;

[CreateAssetMenu(fileName = "AssetProviderService_Installer", menuName = "Game/Installers/AssetProviderService_Installer")]
public class AssetProviderService_Installer : FeatureInstaller
{
    private IAssetProviderService _service;

    public override IFeature Create()
    {
        _service = new AssetProviderService();

        DI.Bind(_service);

        Log.PrintColor($"[AssetProviderService] Create and Bind", Color.cyan);

        return _service;
    }

    public override void Dispose() { }
}
