using System;
using Cysharp.Threading.Tasks;
using Lukomor.Application.Scenes;
using Lukomor.Common.DIContainer;
using Lukomor.Domain.Contexts;
using Lukomor.Domain.Scenes;

namespace Lukomor.Application
{
    public static class Game
    {
        public static event Action ProjectContextPreInitialized;
        public static event Action ProjectContextInitialized;
        public static event Action GameStarted;
        
        public static bool IsStarted { get; private set; }
        public static bool IsMainObjectsBound { get; private set; }
        public static bool IsProjectContextInitialized { get; private set; }
        
        private static ProjectContext _projectContext { get; set; }
        private static bool _gameStarting { get; set; }

        public static async UniTask StartGameAsync(ProjectContext projectContext)
        {
            if (!IsStarted && !_gameStarting)
            {
                IsMainObjectsBound = false;
                IsProjectContextInitialized = false;
                
                _gameStarting = true;
                _projectContext = projectContext;

                ISceneManager sceneManager = SceneManager.CreateInstance(_projectContext);

                DI.Bind(sceneManager);

                IsMainObjectsBound = true;
                ProjectContextPreInitialized?.Invoke();

                if (projectContext != null)
                {
                    await _projectContext.InitializeAsync();
                }

                IsProjectContextInitialized = true;
                ProjectContextInitialized?.Invoke();

                IsStarted = true;
                _gameStarting = false;
                
                GameStarted?.Invoke();
            }
        }
    }
}