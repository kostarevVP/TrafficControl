using Lukomor.Common.DIContainer;
using Lukomor.Domain.Contexts;
using Lukomor.Domain.Features;
using Lukomor.Extentions;
using UnityEngine;

namespace Lukomor.Features.Scenes
{
    [CreateAssetMenu(fileName = "SceneManagerService_Installer", menuName = "Game/Installers/SceneManagerService_Installer")]
    public class SceneManagerService_Installer : FeatureInstaller
    {
        [SerializeField] private GameObject _loadingScreenPrefab;

        private ISceneManagementService _sceneManagementService;

        public override IFeature Create()
        {
            InstallBindings();

            return _sceneManagementService;
        }

        public override void Dispose()
        {
            
        }

        public void InstallBindings()
        {
            ILoadingScreen loadingScreen = default;

            if (_loadingScreenPrefab != null)
            {
                var loadingScreenGo = Instantiate(_loadingScreenPrefab);
                loadingScreen = loadingScreenGo.GetComponent<ILoadingScreen>();

                DontDestroyOnLoad(loadingScreenGo);
            }

            _sceneManagementService = new SceneManagementService(loadingScreen);

            DI.Bind(_sceneManagementService);
        }

        private void OnValidate()
        {
            if (_loadingScreenPrefab != null && _loadingScreenPrefab.GetComponent<ILoadingScreen>() == null)
            {
                Log.PrintWarning($"SceneManagerInstaller doesn't have any ILoadingScreen component.");
            }
        }
    }
}