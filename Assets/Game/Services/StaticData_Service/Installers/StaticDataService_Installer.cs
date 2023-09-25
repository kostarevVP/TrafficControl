using Lukomor.Common.DIContainer;
using Lukomor.Domain.Contexts;
using Lukomor.Domain.Features;
using Lukomor.Extentions;
using UnityEngine;

    [CreateAssetMenu(fileName = "StaticDataService_Installer", menuName = "Game/Installers/StaticDataService_Installer")]
public class StaticDataService_Installer : FeatureInstaller
{
    private IStaticDataService _feature;
    public override IFeature Create()
    {
        _feature = new StaticDataService();

        _feature.LoadGameProgressConfig();
        _feature.LoadSceneConfigs();    

        DI.Bind(_feature);
        Log.PrintColor($"[IStaticDataService] Create and Bind", Color.cyan);


        return _feature;
    }

    public override void Dispose() { }
}
