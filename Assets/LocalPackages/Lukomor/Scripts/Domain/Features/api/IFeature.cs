using Cysharp.Threading.Tasks;

namespace Lukomor.Domain.Features
{
	public interface IFeature
	{
		bool IsReady { get; }

        UniTask InitializeAsync();
        UniTask DestroyAsync();

		void OnApplicationFocus(bool hasFocus);
		void OnApplicationPause(bool pauseStatus);
    }
}