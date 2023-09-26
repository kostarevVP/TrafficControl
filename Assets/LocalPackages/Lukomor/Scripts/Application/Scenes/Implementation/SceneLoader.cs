using System;
using Cysharp.Threading.Tasks;
using WKosArch.Common.Utils.Async;
using WKosArch.Domain.Contexts;
using WKosArch.Domain.Scenes;
using UnityEngine;

namespace WKosArch.Application.Scenes
{
    public class SceneLoader : ISceneLoader
    {
        private const float Progress90 = 0.90f;

        public bool IsLoading { get; private set; }

        public string CurrentSceneName { get; private set; }
        public int CurrentSceneIndex { get; private set; }

        private bool isLoadingUnityScene { get; set; }

        private readonly string[] _sceneNames;
        private readonly ProjectContext _projectContext;
        private IContext _currentSceneContext;

        public SceneLoader(ProjectContext projectContext, string[] sceneNames)
        {
            _projectContext = projectContext;
            _sceneNames = sceneNames;
        }

        public async UniTask LoadScene(int sceneIndex, Action<SceneLoadingArgs> callback = null)
        {
            if (_sceneNames == null || _sceneNames.Length < sceneIndex + 1)
            {
                Debug.LogError($"SceneLoader: cannot load scene with index {sceneIndex}. Index out of range");

                var args = new SceneLoadingArgs
                {
                    SceneIndex = sceneIndex,
                    Success = false
                };

                callback?.Invoke(args);
            }
            else
            {
                var sceneName = _sceneNames[sceneIndex];



                await LoadSceneAsync(sceneName, callback);
            }
        }

        public async UniTask LoadScene(string sceneName, Action<SceneLoadingArgs> callback = null)
        {
            await LoadSceneAsync(sceneName, callback);
        }

        public async UniTask ReloadScene(Action<SceneLoadingArgs> callback = null)
        {
            var sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

            await LoadSceneAsync(sceneName, callback);
        }

        private async UniTask LoadSceneAsync(string sceneName, Action<SceneLoadingArgs> callback = null)
        {
            var args = new SceneLoadingArgs
            {
                SceneName = sceneName,
                SceneIndex = Array.IndexOf(_sceneNames, sceneName),
                Success = false
            };

            if (IsLoading)
            {
                Debug.LogError($"SceneLoader: cannot load scene {sceneName}. Another scene is loading now");

                callback?.Invoke(args);
            }
            else
            {
                IsLoading = true;

                UnloadCurrentSceneContext();

                await LoadUnitySceneTo100PercentAsync(sceneName);

                SceneContext loadedSceneContext = await LoadContext(sceneName);


                IsLoading = false;
                args.Success = true;

                CurrentSceneIndex = args.SceneIndex;
                CurrentSceneName = args.SceneName;

                await UnityAwaiters.WaitNextFrame();

                callback?.Invoke(args);

                await UniTask.CompletedTask;
            }
        }

        private void UnloadCurrentSceneContext()
        {
            _currentSceneContext?.Destroy();
        }

        private async UniTask<SceneContext> LoadContext(string sceneName)
        {
            SceneContext sceneContext = _projectContext.GetSceneContext(sceneName);

            if (sceneContext != null)
            {
                _currentSceneContext = sceneContext;

                await sceneContext.InitializeAsync();
            }

            return sceneContext;
        }

        private async UniTask LoadUnitySceneTo90PercentAsync(string sceneName)
        {
            isLoadingUnityScene = true;

            var asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
            asyncOperation.allowSceneActivation = false;

            while (asyncOperation.progress < Progress90)
            {
                await UniTask.Yield();
            }

            asyncOperation.allowSceneActivation = true;

            isLoadingUnityScene = false;

            await UnityAwaiters.WaitNextFrame();
        }

        private async UniTask LoadUnitySceneTo100PercentAsync(string sceneName)
        {
            isLoadingUnityScene = true;

            var asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);

            while (!asyncOperation.isDone)
            {
                await UniTask.Yield();
            }

            isLoadingUnityScene = false;

            await UnityAwaiters.WaitNextFrame();
        }
    }
}