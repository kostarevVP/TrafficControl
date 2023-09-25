
namespace Assets.Game.Services.Progress_Service.api
{
    public interface ISavedProgress : ILoadProgress
    {
        public void SaveProgress(GameProgress progress);
    }

    public interface ILoadProgress
    {
        public void LoadProgress(GameProgress progress);
    }

}
