using Cysharp.Threading.Tasks;
using UnityEngine;

public class AssetProviderService : IAssetProviderService
{
    private bool _isReady;

    public bool IsReady => _isReady;


    public GameObject Instantiate(string path)
    {
        var prefab = Resources.Load<GameObject>(path);
        return Object.Instantiate(prefab);
    }

    public GameObject Instantiate(string path, Vector3 at)
    {
        var prefab = Resources.Load<GameObject>(path);
        return Object.Instantiate(prefab, at, Quaternion.identity);
    }

    public GameObject Instantiate(string path, Vector3 at, Quaternion rotaion)
    {
        var prefab = Resources.Load<GameObject>(path);
        return Object.Instantiate(prefab, at, rotaion);
    }

    public GameObject Load(string path)
    {
        return Resources.Load<GameObject>(path);
    }

    public UniTask DestroyAsync() =>
        UniTask.CompletedTask;

    public UniTask InitializeAsync()
    {
        _isReady = true;
        return UniTask.CompletedTask;
    }

    public void OnApplicationFocus(bool hasFocus) { }

    public void OnApplicationPause(bool pauseStatus) { }
}
