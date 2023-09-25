using Cysharp.Threading.Tasks;
using Lukomor.Domain.Scenes;
using Lukomor.Extentions;

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
            Log.PrintWarning($"UIService OnSceneLoadedEvent subscribe");

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

            Log.PrintColor($"UIService OnSceneLoadedEvent call", UnityEngine.Color.green);
            Log.PrintColor($"SceneLoadingArgs args.SceneName={args.SceneName}", UnityEngine.Color.green);
            var config = _staticDataService.SceneConfigsMap[args.SceneName];
            Log.PrintColor($"config={config.name}", UnityEngine.Color.green);

            UI.Build(config);
        }

        public void OnApplicationFocus(bool hasFocus) { }

        public void OnApplicationPause(bool pauseStatus) { }
    }
}