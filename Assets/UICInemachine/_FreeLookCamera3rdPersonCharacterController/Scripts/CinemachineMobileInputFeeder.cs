using Cinemachine;
using WKosArch.Extentions;
using UnityEngine;


public class CinemachineMobileInputFeeder : MonoBehaviour
{
    private UITouchPanel _touchInput;

    private Vector2 _lookInput;

    [SerializeField] private float _touchSpeedSensitivityX = 3f;
    [SerializeField] private float _touchSpeedSensitivityY = 3f;

    private string _touchXMapTo = "Mouse X";
    private string _touchYMapTo = "Mouse Y";

    void Start()
    {
        CinemachineCore.GetInputAxis = GetInputAxis;
        var panel = FindFirstObjectByType<UITouchPanel>();
        Log.Print($"panel = {panel}");
        Inject(panel);
    }

    public void Inject(UITouchPanel panel)
    {
        _touchInput = panel;
    }

    private float GetInputAxis(string axisName)
    {
        _lookInput = _touchInput.PlayerJoystickOutputVector();

        if (axisName == _touchXMapTo)
            return _lookInput.x / _touchSpeedSensitivityX;

        if (axisName == _touchYMapTo)
            return _lookInput.y / _touchSpeedSensitivityY;

        return Input.GetAxis(axisName);
    }
}


