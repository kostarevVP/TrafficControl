using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WKosArch.Services.UIService;

namespace WKosArch.Services.StaticDataServices
{
    public class StaticDataService : IStaticDataService
    {
        private const string GameProgressPath = "NewGameProgressStaticData";
        private const string SceneConfigsFolderPath = "SeneConfigs";

        public GameProgressConfig GameProgressConfig => _gameProgressStaticData;
        public Dictionary<string, UISceneConfig> SceneConfigsMap => _sceneConfigsMap;
        public bool IsReady => _isReady;


        private GameProgressConfig _gameProgressStaticData;
        private Dictionary<string, UISceneConfig> _sceneConfigsMap = new Dictionary<string, UISceneConfig>();

        private bool _isReady;

        public StaticDataService()
        {
            LoadGameProgressConfig();
            LoadSceneConfigs();

            _isReady = true;
        }

        public void Dispose()
        {
            Clear();
        }

        private void LoadGameProgressConfig()
        {
            _gameProgressStaticData = Resources.Load<GameProgressConfig>(GameProgressPath);
        }

        private void LoadSceneConfigs()
        {
            _sceneConfigsMap = Resources.LoadAll<UISceneConfig>(SceneConfigsFolderPath)
                .ToDictionary(conf => conf.SceneName, conf => conf);
        }

        private void Clear()
        {
            _gameProgressStaticData = null;
            _sceneConfigsMap.Clear();
        }
    } 
}
