using Cinemachine;
using Cysharp.Threading.Tasks;
using Lukomor.Extentions;
using UnityEngine;
using WKosArch.UI_Service;

public class LoadLevelFeature : ILoadLevelFeature
{
    public const string LookPointTag = "LookPoint";

    private readonly IGameFactoryFeature _gameFactoryFeature;
    private readonly UserInterface _ui;

    private bool _isReady;

    public bool IsReady => _isReady;


    public LoadLevelFeature(IGameFactoryFeature gameFactoryFeature, UserInterface ui)
    {
        _gameFactoryFeature = gameFactoryFeature;
        _ui = ui;
    }

    #region IFeature
    public UniTask InitializeAsync()
    {
        _isReady = true;
        return UniTask.CompletedTask;
    }

    public UniTask DestroyAsync() =>
        UniTask.CompletedTask;

    public void OnApplicationFocus(bool hasFocus) { }
    public void OnApplicationPause(bool pauseStatus) { }

    #endregion


    public void LoadGameLevelEnviroment()
    {
        _gameFactoryFeature.CreateFreeLookCamera();

        var camera = _gameFactoryFeature.FreeLookCamera;

        ShowSettingButton();
        SetPlayerToCamera(camera);
    }

    private void ShowSettingButton()
    {
        Log.PrintWarning($"ShowSettingButton _ui==null = {_ui == null}");
        _ui.ShowWindow<SettingButtonViewModel>();
    }

    private void SetPlayerToCamera(GameObject freeLookCamera)
    {
        var cinemachineCamera = freeLookCamera.GetComponent<CinemachineFreeLook>();

        var lookFollowPoint = GameObject.FindGameObjectWithTag(LookPointTag).transform;


        cinemachineCamera.LookAt = lookFollowPoint;
        cinemachineCamera.Follow = lookFollowPoint;
    }
}
