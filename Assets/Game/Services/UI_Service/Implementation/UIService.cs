using Cysharp.Threading.Tasks;
using Lukomor.Domain.Scenes;
using Lukomor.Features.Scenes;
using System;

namespace WKosArch.UI_Service
{
    public class UIService : IUIService
    {
        //private readonly ISceneManager _sceneManger;
        private readonly ISceneManagementService _sceneManagementService;
        private readonly IStaticDataService _staticDataService;


        private bool _isReady;

        public UserInterface UI { get; private set; }

        public bool IsReady => _isReady;

        public UIService(IStaticDataService staticDataService, ISceneManagementService sceneManagementService)
        {
            //_sceneManger = sceneManger;
            _staticDataService = staticDataService;
            _sceneManagementService = sceneManagementService;

            UI = UserInterface.CreateInstance();
            _sceneManagementService.SceneLoaded += SceneLoaded;
            //_sceneManger.OnSceneLoadedEvent += SceneLoaded;
        }

        private void SceneLoaded(string sceneName)
        {
            var config = _staticDataService.SceneConfigsMap[sceneName];

            UI.Build(config);
        }

        public UniTask InitializeAsync()
        {

            return UniTask.CompletedTask;
        }


        public UniTask DestroyAsync()
        {
            _sceneManagementService.SceneLoaded -= SceneLoaded;

            return UniTask.CompletedTask;
        }

        //private void SceneLoaded(SceneLoadingArgs args)
        //{

        //    var config = _staticDataService.SceneConfigsMap[args.SceneName];

        //    UI.Build(config);
        //}

        public void OnApplicationFocus(bool hasFocus) { }

        public void OnApplicationPause(bool pauseStatus) { }
    }
}