using Lukomor.Domain.Features;
using Lukomor.Features.Scenes;

public interface ILoadLevelFeature : IFeature
{
    void LoadGameLevelEnviroment(ISceneManagementService _sceneManagementService);
}