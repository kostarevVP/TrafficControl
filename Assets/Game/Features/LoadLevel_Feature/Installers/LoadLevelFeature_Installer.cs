using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using WKosArch.Services.Scenes;
using UnityEngine;
using WKosArch.Services.UIService;

namespace WKosArch.Features.LoadLevelFeature
{
    [CreateAssetMenu(fileName = "LoadLevelFeature_Installer", menuName = "Game/Installers/LoadLevelFeature_Installer")]
    public class LoadLevelFeature_Installer : FeatureInstaller
    {
        private ILoadLevelFeature _feature;
        private ISceneManagementService _sceneManagementService;

        public override IFeature Create(IDIContainer container)
        {
            _sceneManagementService = container.Resolve<ISceneManagementService>();
            var gameFactoryFeature = container.Resolve<IGameFactoryFeature>();
            var ui = container.Resolve<UserInterface>();

            _feature = new LoadLevelFeature(gameFactoryFeature, ui);

            container.Bind(_feature);

            Log.PrintColor($"[ILoadLevelFeature] Create and Bind", Color.cyan);

            _sceneManagementService.SceneLoaded += SceneLoaded;

            return _feature;
        }

        public override void Dispose()
        {
            _sceneManagementService.SceneLoaded -= SceneLoaded;
        }

        private void SceneLoaded(string sceneName)
        {
            Log.PrintColor($"LoadLevleFeature SceneLoaded({sceneName}) Start LoadGameLevelEnviroment", Color.yellow);
            _feature.LoadGameLevelEnviroment(_sceneManagementService);
        }
    }
}
