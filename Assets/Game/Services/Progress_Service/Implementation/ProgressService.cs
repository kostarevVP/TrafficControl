using Assets.Game.Services.Progress_Service.api;
using Cysharp.Threading.Tasks;

namespace Assets.Game.Services.Progress_Service.Implementation
{
    public class ProgressService : IProgressService
    {
        private bool _isReady;

        public GameProgress Progress { get; set; }

        public bool IsReady => _isReady;

        public UniTask DestroyAsync()
        {
           return UniTask.CompletedTask;
        }

        public UniTask InitializeAsync()
        {
            _isReady = true;
            return UniTask.CompletedTask;
        }

        public void OnApplicationFocus(bool hasFocus) { }

        public void OnApplicationPause(bool pauseStatus) { }
    }
}