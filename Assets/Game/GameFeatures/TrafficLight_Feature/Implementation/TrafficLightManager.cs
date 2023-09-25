using UnityEngine;
using UnityEngine.EventSystems;

public class TrafficLightManager : MonoBehaviour
{
    [SerializeField] private TrafficLightTouchDetector _detector;
    [SerializeField] private TrafficLightSwitcher _switcher;

    private void OnEnable()
    {
        _detector.OnDetectTouchEvent += SwitchTrafficLight;
    }

    private void OnDisable()
    {
        _detector.OnDetectTouchEvent -= SwitchTrafficLight;

    }

    private void SwitchTrafficLight(PointerEventData data)
    {
        _switcher.SwitchTrafficLight();
    }
}
