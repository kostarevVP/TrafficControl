using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using WKosArch.UI_Service.Views.Windows;

namespace WKosArch.UI_Service
{
    [CreateAssetMenu(fileName = "UI_SceneConfig", menuName = "UI/Configs/_UI_SceneConfig")]
    public class UISceneConfig : ScriptableObject
    {
        [SerializeField] private WindowViewModel[] _windowPrefabs;

        public WindowViewModel[] WindowPrefabs => _windowPrefabs;

        [HideInInspector] public string SceneName;
        [HideInInspector] public int SceneIndex;

#if UNITY_EDITOR
        [Space]
        [SerializeField] private SceneAsset _firstSceneToLoad;

        private void OnValidate()
        {
            if (_firstSceneToLoad != null)
            {
                SceneName = _firstSceneToLoad.name;
                SceneIndex = GetSceneIndexByName(SceneName);
            }
        }
#endif

        public bool TryGetPrefab<T>(out T requestedPrefab) where T : WindowViewModel
        {
            requestedPrefab = null;

            foreach (var prefab in _windowPrefabs)
            {
                if (prefab is T certainPrefab)
                {
                    requestedPrefab = certainPrefab;

                    break;
                }
            }

            return requestedPrefab != null;
        }

        private int GetSceneIndexByName(string sceneName)
        {
            int sceneCount = SceneManager.sceneCountInBuildSettings;

            for (int i = 0; i < sceneCount; i++)
            {
                string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                string sceneNameInBuildSettings = System.IO.Path.GetFileNameWithoutExtension(scenePath);

                if (sceneNameInBuildSettings == sceneName)
                    return i;
            }

            Debug.LogError("Scene not found in build settings: " + sceneName);
            return -1;
        }
    }
}
