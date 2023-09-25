using Lukomor.Common.DIContainer;
using UnityEngine;
using WKosArch.UI_Service;

public class BackButtonHandler : MonoBehaviour
{
    private UserInterface _ui;

    private void Start()
    {
        _ui = new DIVar<UserInterface>().Value;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _ui.ShowWindow<CloseAppViewModel>();
        }
    }
}
