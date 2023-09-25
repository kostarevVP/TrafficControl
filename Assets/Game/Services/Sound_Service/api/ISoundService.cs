using Lukomor.Domain.Features;
using WKosArch.Representation.Audio_Service;

public interface ISoundService : IFeature
{
    SoundManager SoundManager { get; }
}