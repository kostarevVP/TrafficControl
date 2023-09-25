using Assets.Game.Services.Progress_Service.api;
using Cysharp.Threading.Tasks;

public class LoadProgressFeature : ILoadProgressFeature
{
    public bool IsReady => _isReady;

    private readonly IProgressService _progressService;
    private readonly ISaveLoadService _saveLoadService;
    private readonly IStaticDataService _staticDataService;
    private bool _isReady;

    public LoadProgressFeature(IProgressService progressService, ISaveLoadService saveLoadService, IStaticDataService staticDataService)
    {
        _progressService = progressService;
        _saveLoadService = saveLoadService;
        _staticDataService = staticDataService;
    }

    public UniTask InitializeAsync()
    {
        _isReady = true;
        return UniTask.CompletedTask;
    }

    public void LoadProgressOrInitNew() =>
        _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();

    private GameProgress NewProgress()
    {
        var progress = new GameProgress();

        progress.SceneIndex = _staticDataService.GameProgressConfig.SceneIndex;

        return progress;
    }

    public UniTask DestroyAsync()
    {
        return UniTask.CompletedTask;
    }

    public void OnApplicationFocus(bool hasFocus) { }
    public void OnApplicationPause(bool pauseStatus) { }
}
