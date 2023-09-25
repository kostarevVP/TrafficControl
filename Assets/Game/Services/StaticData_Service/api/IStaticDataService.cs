using Lukomor.Domain.Features;
using System.Collections.Generic;
using WKosArch.UI_Service;

public interface IStaticDataService : IFeature
{
    GameProgressConfig GameProgressConfig { get;}
    Dictionary<string, UISceneConfig> SceneConfigsMap { get; }

    void LoadGameProgressConfig();
    void LoadSceneConfigs();
}