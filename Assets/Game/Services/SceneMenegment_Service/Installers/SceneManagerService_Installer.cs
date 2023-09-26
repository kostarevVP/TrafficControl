using Cysharp.Threading.Tasks;
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
        private ProjectContext _projectContext;

        public override IFeature Create()
        {
            _projectContext = new DIVar<ProjectContext>().Value;

            InstallBindings();

            _sceneManagementService.SceneChanged += LoadSceneContext;

            return _sceneManagementService;
        }

        private async void LoadSceneContext(string sceneName)
        {
            await LoadContext(sceneName);
        }

        public override void Dispose()
        {
            _sceneManagementService.SceneChanged -= LoadSceneContext;

        }

        public void InstallBindings()
        {
            ILoadingScreen loadingScreen = IsntatiateLoadingScreen();

            _sceneManagementService = new SceneManagementService(loadingScreen);

            DI.Bind(_sceneManagementService);
        }

        private ILoadingScreen IsntatiateLoadingScreen()
        {
            ILoadingScreen loadingScreen = default;

            if (_loadingScreenPrefab != null)
            {
                var loadingScreenGo = Instantiate(_loadingScreenPrefab);
                loadingScreen = loadingScreenGo.GetComponent<ILoadingScreen>();

                DontDestroyOnLoad(loadingScreenGo);
            }

            return loadingScreen;
        }
        private async UniTask<SceneContext> LoadContext(string sceneName)
        {
            SceneContext sceneContext = _projectContext.GetSceneContext(sceneName);

            if (sceneContext != null)
            {
                await sceneContext.InitializeAsync();
            }

            return sceneContext;
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