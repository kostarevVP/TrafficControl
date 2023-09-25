using UnityEngine;

namespace Lukomor.Domain.Contexts
{
    public sealed class SceneContext : MonoContext
    {
        [Space]
#if UNITY_EDITOR
        [SerializeField] private UnityEditor.SceneAsset _scene;
#endif
        [HideInInspector] public string SceneName;

        private void OnValidate()
        {
#if UNITY_EDITOR
            if (_scene != null)
            {
                SceneName = _scene.name;
            }
#endif
        }
    }
}