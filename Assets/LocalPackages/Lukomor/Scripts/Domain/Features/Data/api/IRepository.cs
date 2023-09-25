using Cysharp.Threading.Tasks;

namespace Lukomor.Data
{
    public interface IRepository
    {
        UniTask Save();
        UniTask Load();
    }
}