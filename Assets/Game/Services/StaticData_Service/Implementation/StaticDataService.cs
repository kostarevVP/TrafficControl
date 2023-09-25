using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WKosArch.UI_Service;

public class StaticDataService : IStaticDataService
{
    private const string GameProgressPath = "NewGameProgressStaticData";
    private const string SceneConfigsFolderPath = "SeneConfigs";

    private GameProgressConfig _gameProgressStaticData;
    private Dictionary<string, UISceneConfig> _sceneConfigsMap;

    private bool _isReady;
    public bool IsReady => _isReady;

    public GameProgressConfig GameProgressConfig => _gameProgressStaticData;
    public Dictionary<string, UISceneConfig> SceneConfigsMap => _sceneConfigsMap;

    public UniTask InitializeAsync()
    {
        _isReady = true;
        return UniTask.CompletedTask;
    }

    public void LoadGameProgressConfig()
    {
        _gameProgressStaticData = Resources.Load<GameProgressConfig>(GameProgressPath);
    }
    
    public void LoadSceneConfigs()
    {
        _sceneConfigsMap = Resources.LoadAll<UISceneConfig>(SceneConfigsFolderPath)
            .ToDictionary(conf => conf.SceneName, conf => conf);
    }

    public void OnApplicationFocus(bool hasFocus) { }
    public void OnApplicationPause(bool pauseStatus) { }
    public UniTask DestroyAsync() =>
        UniTask.CompletedTask;
}
