using WKosArch.Domain.Features;

namespace WKosArch.Services.SoundService
{
    public interface ISoundService : IFeature
    {
        SoundManager SoundManager { get; }
    }
}