using Assets.Game.Services.Progress_Service.api;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using WKosArch.Representation.Audio_Service;

public class SoundService : ISoundService
{
    public SoundManager SoundManager { get; private set; }
    public List<ILoadProgress> ProgressReaders { get; } = new List<ILoadProgress>();
    public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();
    public bool IsReady => _isReady;


    private bool _isReady;

    public UniTask InitializeAsync()
    {
        SoundManager = SoundManager.CreateInstance();
        RegisterProgressWatchers(SoundManager);
        _isReady = true;
        return UniTask.CompletedTask;
    }

    public UniTask DestroyAsync() =>
        UniTask.CompletedTask;

    private void RegisterProgressWatchers(SoundManager gameObject)
    {
        foreach (var progressReader in gameObject.GetComponentsInChildren<ISavedProgress>())
        {
            Register(progressReader);
        }
    }

    private void Register(ISavedProgress progressReader)
    {
        if (progressReader is ISavedProgress progressWriter)
        {
            ProgressWriters.Add(progressWriter);
        }

        ProgressReaders.Add(progressReader);
    }

    public void OnApplicationFocus(bool hasFocus) { }

    public void OnApplicationPause(bool pauseStatus) { }
}
