using Lukomor.Domain.Features;

namespace Assets.Game.Services.Progress_Service.api
{
    public interface IProgressService : IFeature
    {
        GameProgress Progress { get; set; }
    }
}