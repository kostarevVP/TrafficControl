using System.Linq;
using UnityEngine;

namespace Lukomor.Domain.Contexts
{
    public sealed class ProjectContext : MonoContext
    {
        [Space]
        [SerializeField] private SceneContext[] _sceneContexts;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public SceneContext GetSceneContext(string sceneName)
        {
            var result = _sceneContexts.FirstOrDefault(c => c.SceneName == sceneName);
            
            return result;
        }
    }
}