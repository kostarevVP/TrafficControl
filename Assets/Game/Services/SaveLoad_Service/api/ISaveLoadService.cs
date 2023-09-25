using Lukomor.Domain.Features;

public interface ISaveLoadService : IFeature
{
    public GameProgress LoadProgress();
    public void SaveProgress();
}
