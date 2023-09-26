using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using UnityEngine;

namespace WKosArch.GameFactoryFeature
{
    [CreateAssetMenu(fileName = "GameFactoryFeature_Installer", menuName = "Game/Installers/GameFactoryFeature_Installer")]
    public class GameFactoryFeature_Installer : FeatureInstaller
    {
        private IGameFactoryFeature _feature;

        public override IFeature Create(IDIContainer container)
        {
            var assetProviderService = container.Resolve<IAssetProviderService>();

            _feature = new GameFactoryFeature(assetProviderService);

            container.Bind(_feature);

            Log.PrintColor($"[IGameFactoryFeature] Create and Bind", Color.cyan);

            return _feature;
        }

        public override void Dispose() { }
    }
}