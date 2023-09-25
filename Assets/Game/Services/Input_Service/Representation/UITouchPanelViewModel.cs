using UnityEngine;
using WKosArch.UI_Service.Views.Windows;

public class UITouchPanelViewModel : WindowViewModel
{
    public UITouchPanel UiTouchPanel
    {
        get
        {
            if (_uiTouchPanel == null)
            {
                _uiTouchPanel = GetComponent<UITouchPanel>();
            }

            return _uiTouchPanel;
        }
    }

    [SerializeField] private UITouchPanel _uiTouchPanel;

}
