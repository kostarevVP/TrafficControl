using UnityEngine;

namespace WKosArch.UI_Service.Common
{
    public class UILayerContainer : MonoBehaviour
    {
        [SerializeField] private UILayer _layer;

        public UILayer layer => _layer;
    }
}