using Cysharp.Threading.Tasks;
using Lukomor.Domain.Scenes;

namespace WKosArch.UI_Service
{
    public class UIService : IUIService
    {
        private readonly ISceneManager _sceneManger;
        private readonly IStaticDataService _staticDataService;


        private bool _isReady;

        public UserInterface UI { get; private set; }

        public bool IsReady => _isReady;

        public UIService(ISceneManager sceneManger, IStaticDataService staticDataService)
        {
            _sceneManger = sceneManger;
            _staticDataService = staticDataService;

            UI = UserInterface.CreateInstance();
            _sceneManger.OnSceneLoadedEvent += SceneLoaded;
        }

        public UniTask InitializeAsync()
        {

            return UniTask.CompletedTask;
        }


        public UniTask DestroyAsync()
        {
            _sceneManger.OnSceneLoadedEvent -= SceneLoaded;

            return UniTask.CompletedTask;
        }

        private void SceneLoaded(SceneLoadingArgs args)
        {

            var config = _staticDataService.SceneConfigsMap[args.SceneName];

            UI.Build(config);
        }

        public void OnApplicationFocus(bool hasFocus) { }

        public void OnApplicationPause(bool pauseStatus) { }
    }
}