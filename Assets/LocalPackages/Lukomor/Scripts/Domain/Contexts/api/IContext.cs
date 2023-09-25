using Cysharp.Threading.Tasks;

namespace Lukomor.Domain.Contexts
{
	public interface IContext
	{
		bool IsReady { get; }

        UniTask InitializeAsync();
		void Destroy();
	}
}