using Lukomor.Common.DIContainer;
using Lukomor.Domain.Contexts;
using Lukomor.Domain.Features;
using Lukomor.Extentions;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundService_Installer", menuName = "Game/Installers/SoundService_Installer")]
public class SoundService_Installer : FeatureInstaller
{
    private ISoundService _service;
    public override IFeature Create()
    {
        _service = new SoundService();

        DI.Bind(_service);
        Log.PrintColor($"[ISoundService] Create and Bind", Color.cyan);

        return _service;
    }

    public override void Dispose()
    {

    }
}
