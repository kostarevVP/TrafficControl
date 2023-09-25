using Cysharp.Threading.Tasks;
using System;

namespace Lukomor.Domain.Scenes
{
    public interface ISceneManager
    {
        event Action SceneLoading;
        //event Action<bool> SceneLoaded;
        event Action<SceneLoadingArgs> OnSceneLoadedEvent;

        bool IsLoading { get; }
        string CurrentSceneName { get; }
        int CurreneSceneIndex { get; }

        UniTask LoadScene(int sceneIndex);
        UniTask LoadScene(string sceneName);
        UniTask ReloadScene();
    }
}