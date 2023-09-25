using Lukomor.Common.DIContainer;
using Lukomor.Domain.Contexts;
using Lukomor.Domain.Features;
using Lukomor.Extentions;
using UnityEngine;

[CreateAssetMenu(fileName = "GameFactoryFeature_Installer", menuName = "Game/Installers/GameFactoryFeature_Installer")]
public class GameFactoryFeature_Installer : FeatureInstaller
{
    private IGameFactoryFeature _feature;

    public override IFeature Create()
    {
        var assetProviderService = new DIVar<IAssetProviderService>().Value;

        _feature = new GameFactoryFeature(assetProviderService);

        DI.Bind(_feature);
        Log.PrintColor($"[IGameFactoryFeature] Create and Bind", Color.cyan);

        return _feature;
    }

    public override void Dispose() { }
}
