using Cysharp.Threading.Tasks;
using Lukomor.Domain.Features;

public interface ILoadProgressFeature : IFeature
{
    void LoadProgressOrInitNew();
}