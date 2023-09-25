using System;
using WKosArch.UI_Service.Common;

namespace WKosArch.UI_Service.Views.Windows
{
    [Serializable]
    public struct WindowSettings
    {
        public UILayer TargetLayer;
        public bool IsPreCached;
        public bool OpenWhenCreated;
    }
}