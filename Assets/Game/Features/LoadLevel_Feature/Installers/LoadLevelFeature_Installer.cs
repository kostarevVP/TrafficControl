using Lukomor.Common.DIContainer;
using Lukomor.Domain.Contexts;
using Lukomor.Domain.Features;
using Lukomor.Domain.Scenes;
using Lukomor.Extentions;
using Lukomor.Features.Scenes;
using System;
using UnityEngine;
using WKosArch.UI_Service;

[CreateAssetMenu(fileName = "LoadLevelFeature_Installer", menuName = "Game/Installers/LoadLevelFeature_Installer")]
public class LoadLevelFeature_Installer : FeatureInstaller
{
    private ILoadLevelFeature _feature;

    //private ISceneManager _sceneManager;
    private ISceneManagementService _sceneManagementService;

    public override IFeature Create()
    {
        //_sceneManager = new DIVar<ISceneManager>().Value;
        _sceneManagementService = new DIVar<ISceneManagementService>().Value;

        var gameFactoryFeature = new DIVar<IGameFactoryFeature>().Value;
        var ui = new DIVar<UserInterface>().Value;

        _feature = new LoadLevelFeature(gameFactoryFeature, ui);

        DI.Bind(_feature);
        Log.PrintColor($"[ILoadLevelFeature] Create and Bind", Color.cyan);

        //_sceneManager.OnSceneLoadedEvent += LoadWorldLog;
        _sceneManagementService.SceneLoaded += SceneLoaded;
        Debug.LogWarning($"LoadLevelFeature OnSceneLoadedEvent subscribe");

        //LoadWorldLog(true);

        return _feature;
    }

    private void SceneLoaded(string sceneName)
    {
        Log.PrintColor($"LoadLevleFeature SceneLoaded({sceneName})", Color.yellow);
        _feature.LoadGameLevelEnviroment(_sceneManagementService);
    }

    public override void Dispose()
    {
        //_sceneManager.OnSceneLoadedEvent -= LoadWorldLog;
        _sceneManagementService.SceneLoaded -= SceneLoaded;

    }

    //private void LoadWorldLog(SceneLoadingArgs args)
    //{
    //    Log.PrintColor($"LoadLevelFeature OnSceneLoadedEvent call", UnityEngine.Color.green);

    //    _feature.LoadGameLevelEnviroment();
    //}
}
