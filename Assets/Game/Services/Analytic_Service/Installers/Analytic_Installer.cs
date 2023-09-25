using Lukomor.Common.DIContainer;
using Lukomor.Domain.Contexts;
using Lukomor.Domain.Features;
using Lukomor.Extentions;
using UnityEngine;


[CreateAssetMenu(fileName = "Analytic_Installer", menuName = "Game/Installers/Analytic_Installer")]
public class Analytic_Installer : FeatureInstaller
{
    private IAnalyticService _service;

    public override IFeature Create()
    {
        _service = new AnalyticLogService();

        DI.Bind(_service);

        Log.PrintColor($"[IAnalyticService] Create and Bind", Color.cyan);

        return _service;
    }

    public override void Dispose() { }
}
