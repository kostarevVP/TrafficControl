using Assets.Game.Services.Progress_Service.api;
using Lukomor.Common.DIContainer;
using Lukomor.Domain.Contexts;
using Lukomor.Domain.Features;
using Lukomor.Extentions;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveLoadService_Installer", menuName = "Game/Installers/SaveLoadService_Installer  ")]
public class SaveLoadService_Installer : FeatureInstaller
{
    private ISaveLoadService _service;
    public override IFeature Create()
    {
        var progressService = new DIVar<IProgressService>().Value;
        _service = new SaveLoadService(progressService);

        DI.Bind(_service);

        Log.PrintColor($"[ISaveLoadService] Create and Bind", Color.cyan);

        return _service;
    }

    public override void Dispose() { }
}
