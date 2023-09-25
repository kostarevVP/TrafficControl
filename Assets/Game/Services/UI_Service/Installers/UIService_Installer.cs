using Lukomor.Common.DIContainer;
using Lukomor.Domain.Contexts;
using Lukomor.Domain.Features;
using Lukomor.Domain.Scenes;
using UnityEngine;

namespace WKosArch.UI_Service
{
    [CreateAssetMenu(fileName = "UIService_Installer", menuName = "Game/Installers/UIService_Installer")]
    public class UIService_Installer : FeatureInstaller
    {
        private IUIService _service;
        public override IFeature Create()
        {
            var sceneManager = new DIVar<ISceneManager>().Value;
            var staticDataService = new DIVar<IStaticDataService>().Value; 

            _service = new UIService(sceneManager, staticDataService);


            DI.Bind(_service);
            DI.Bind(_service.UI);
            return _service;
        }

        public override void Dispose()
        {
            DI.Unbind<IUIService>();
        }
    }
}