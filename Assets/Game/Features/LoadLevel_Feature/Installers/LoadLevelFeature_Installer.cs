using Lukomor.Common.DIContainer;
using Lukomor.Domain.Contexts;
using Lukomor.Domain.Features;
using Lukomor.Domain.Scenes;
using Lukomor.Extentions;
using UnityEngine;
using WKosArch.UI_Service;

[CreateAssetMenu(fileName = "LoadLevelFeature_Installer", menuName = "Game/Installers/LoadLevelFeature_Installer")]
public class LoadLevelFeature_Installer : FeatureInstaller
{
    private ILoadLevelFeature _feature;

    private ISceneManager _sceneManager;

    public override IFeature Create()
    {
        _sceneManager = new DIVar<ISceneManager>().Value;

        var gameFactoryFeature = new DIVar<IGameFactoryFeature>().Value;
        var ui = new DIVar<UserInterface>().Value;

        _feature = new LoadLevelFeature(gameFactoryFeature, ui);

        DI.Bind(_feature);
        Log.PrintColor($"[ILoadLevelFeature] Create and Bind", Color.cyan);

        _sceneManager.OnSceneLoadedEvent += LoadWorldLog;
        Debug.LogWarning($"LoadLevelFeature OnSceneLoadedEvent subscribe");

        //LoadWorldLog(true);

        return _feature;
    }

    public override void Dispose()
    {
        _sceneManager.OnSceneLoadedEvent -= LoadWorldLog;
    }

    private void LoadWorldLog(SceneLoadingArgs args)
    {
        Log.PrintColor($"LoadLevelFeature OnSceneLoadedEvent call", UnityEngine.Color.green);

        _feature.LoadGameLevelEnviroment();
    }
}
