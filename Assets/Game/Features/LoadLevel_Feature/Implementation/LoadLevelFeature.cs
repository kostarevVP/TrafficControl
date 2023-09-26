using Cinemachine;
using WKosArch.Services.Scenes;
using UnityEngine;
using WKosArch.Services.UIService;

namespace WKosArch.Features.LoadLevelFeature
{
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

            _isReady = true;
        }

        public void LoadGameLevelEnviroment(ISceneManagementService _sceneManagementService)
        {
            _gameFactoryFeature.CreateFreeLookCamera();

            var camera = _gameFactoryFeature.FreeLookCamera;

            ShowSettingButton();
            SetPlayerToCamera(camera);

            _sceneManagementService.SceneReadyToStart = true;
        }

        private void ShowSettingButton()
        {
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
}