using Lukomor.Application;
using Lukomor.Common.DIContainer;
using Lukomor.Domain.Scenes;
using Lukomor.Extentions;
using Lukomor.Features.Scenes;
using System;
using System.Collections;
using UnityEngine;

namespace Lukomor.TagsGame.Loading.Presentation
{
    public class LoadingScreen : MonoBehaviour, ILoadingScreen
    {
        [SerializeField] private GameObject _goContent;
        [SerializeField] private float _delayTime;

        private static LoadingScreen _instance;

        #region Unity lifecycle
        
        //private void Start()
        //{
        //    if (TryCreateSingleton())
        //    {
        //        if (!Game.IsMainObjectsBound)
        //        {
        //            Game.ProjectContextPreInitialized += OnGameProjectContextPreInitialized;
        //        }
        //        else
        //        {
        //            Init();
        //        }
        //    }
        //}

        //private void OnDestroy()
        //{
        //    if (Game.IsMainObjectsBound)
        //    {
        //        var sceneManager = DI.Get<ISceneManager>();

        //        sceneManager.SceneLoading -= OnSceneLoadingStarted;
        //        sceneManager.OnSceneLoadedEvent -= OnSceneLoaded;
        //    }
        //}

        #endregion

        private bool TryCreateSingleton()
        {
            var singletonCreated = false;

            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                singletonCreated = true;
                _instance = this;

                DontDestroyOnLoad(gameObject);
            }

            return singletonCreated;
        }

        private void Init()
        {
            //var sceneManager = DI.Get<ISceneManager>();

            //sceneManager.SceneLoading += OnSceneLoadingStarted;
            //sceneManager.OnSceneLoadedEvent += OnSceneLoaded;
            //Debug.LogWarning($"LoadingScreen OnSceneLoadedEvent subscribe");
            //if (sceneManager.IsLoading)
            //{
            //    OnSceneLoadingStarted();
            //}
        }

        //private void OnGameProjectContextPreInitialized()
        //{
        //    Game.ProjectContextPreInitialized -= OnGameProjectContextPreInitialized;
        //    Log.PrintWarning("OnGameProjectContextPreInitialized");

        //    Init();
        //}

        private void OnSceneLoadingStarted()
        {
            Log.PrintWarning($"OnSceneLoadingStarted");
            _goContent.SetActive(true);
        }

        private void OnSceneLoaded(SceneLoadingArgs args)
        {
            Log.PrintColor($"LoadingScreen OnSceneLoadedEvent call", UnityEngine.Color.green);


            StartCoroutine(CloseLoadingScreenWithDelay(_delayTime));
        }

        private IEnumerator CloseLoadingScreenWithDelay(float delay)
        {

            yield return new WaitForSeconds(delay);

            _goContent.SetActive(false);
        }

        public void Show(Action onComplete = null)
        {
            _goContent.SetActive(true);
            onComplete?.Invoke();
        }

        public void Hide(Action onComplete = null)
        {
            StartCoroutine(CloseLoadingScreenWithDelay(_delayTime));
            onComplete?.Invoke();
        }
    }
}