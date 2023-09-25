using Assets.Game.Services.Progress_Service.api;
using Assets.Game.Services.Progress_Service.Implementation;
using Lukomor.Common.DIContainer;
using Lukomor.Domain.Contexts;
using Lukomor.Domain.Features;
using Lukomor.Extentions;
using UnityEngine;

[CreateAssetMenu(fileName = "ProgressService_Installer", menuName = "Game/Installers/ProgressService_Installer")]
public class ProgressService_Installer : FeatureInstaller
{
    private IProgressService _service;

    public override IFeature Create()
    {
        _service = new ProgressService();

        DI.Bind(_service);

        Log.PrintColor($"[IProgressService] Create and Bind", Color.cyan);

        return _service;
    }

    public override void Dispose() { }
}
