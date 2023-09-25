using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameFactoryFeature : IGameFactoryFeature
{
    private const string CameraPrefabPath = "FreeLook Camera";

    private readonly IAssetProviderService _assetProviderService;

    private bool _isReady;

    public GameObject FreeLookCamera { get; private set; }


    public bool IsReady => _isReady;

    public GameFactoryFeature(IAssetProviderService assetProviderService)
    {
        _assetProviderService = assetProviderService;
    }

    public void CreateFreeLookCamera()
    {
        FreeLookCamera = _assetProviderService.Instantiate(CameraPrefabPath);
    }

    public UniTask InitializeAsync()
    {
        _isReady = true;
        return UniTask.CompletedTask;
    }

    public UniTask DestroyAsync() =>
        UniTask.CompletedTask;

    public void OnApplicationFocus(bool hasFocus) { }
    public void OnApplicationPause(bool pauseStatus) { }
}