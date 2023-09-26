using Assets.Game.Services.Progress_Service.api;
using Lukomor.Common.DIContainer;
using Lukomor.Domain.Contexts;
using Lukomor.Domain.Features;
using Lukomor.Domain.Scenes;
using Lukomor.Extentions;
using Lukomor.Features.Scenes;
using UnityEngine;

[CreateAssetMenu(fileName = "LoadProgressFeature_Installer", menuName = "Game/Installers/LoadProgressFeature_Installer")]
public class LoadProgressFeature_Installer : FeatureInstaller
{
    private ILoadProgressFeature _feature;
    //private ISceneManager _sceneManager => new DIVar<ISceneManager>().Value;
    public override IFeature Create()
    {
        IProgressService progressService = new DIVar<IProgressService>().Value;
        ISaveLoadService saveLoadService = new DIVar<ISaveLoadService>().Value;
        IStaticDataService staticDataService = new DIVar<IStaticDataService>().Value;
        ISceneManagementService sceneManagementService = new DIVar<ISceneManagementService>().Value;

        _feature = new LoadProgressFeature(progressService, saveLoadService, staticDataService);
        _feature.LoadProgressOrInitNew();


        DI.Bind(_feature);

        Log.PrintColor($"[ILoadProgressFeature] Create and Bind", Color.cyan);

        //_sceneManager.LoadScene(progressService.Progress.SceneIndex);
        sceneManagementService.LoadScene(progressService.Progress.SceneIndex);

        return _feature;
    }

    public override void Dispose() { }
}
