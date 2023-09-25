using Lukomor.Domain.Features;
using UnityEngine;

public interface IAssetProviderService : IFeature
{
    GameObject Instantiate(string path);
    GameObject Instantiate(string path, Vector3 at);
    GameObject Instantiate(string path, Vector3 at, Quaternion rotaion);
    GameObject Load(string path);
}
