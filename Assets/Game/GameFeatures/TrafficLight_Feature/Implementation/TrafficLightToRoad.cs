using WKosArch.Extentions;
using TurnTheGameOn.SimpleTrafficSystem;
using UnityEngine;

public class TrafficLightToRoad : MonoBehaviour
{
    [SerializeField] private AITrafficLight _trafficLight;

    [SerializeField] private Light _light;

    private void Start() => 
        SwitchLight(_trafficLight.State);

    private void OnEnable() => 
        _trafficLight.OnChangeStateEvent += SwitchLight;

    private void OnDisable() => 
        _trafficLight.OnChangeStateEvent -= SwitchLight;

    private void SwitchLight(TrafficLightState state)
    {
        switch (state)
        {
            case TrafficLightState.GreenState:
                _light.color = Color.green;
                Log.Print("GreenState");
                break;
            case TrafficLightState.YellowState:
                _light.color = Color.yellow;
                Log.Print("YellowState");

                break;
            case TrafficLightState.RedState:
                _light.color = Color.red;
                Log.Print("RedState");

                break;
            default:
                _light.enabled = false;
                Log.Print("default");

                break;
        }
    }
}
