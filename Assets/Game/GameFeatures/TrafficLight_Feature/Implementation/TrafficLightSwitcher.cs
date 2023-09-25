using System.Collections;
using TurnTheGameOn.SimpleTrafficSystem;
using UnityEngine;
using static TurnTheGameOn.SimpleTrafficSystem.AITrafficLightManager;

public class TrafficLightSwitcher : MonoBehaviour
{
    public bool AutoSwitcher;
    [Space]
    public TrafficLightCycle[] trafficLightCycles;

    private void Start()
    {
        EnableRedLights();

        if (AutoSwitcher)
        {
            StartCoroutine(StartTrafficLightCycles());
        }
    }

    public void SwitchTrafficLight()
    {
        StartCoroutine(StartTrafficLightCycle());
    }

    private void EnableRedLights()
    {
        for (int i = 0; i < trafficLightCycles.Length; i++)
        {
            for (int j = 0; j < trafficLightCycles[i].trafficLights.Length; j++)
            {
                trafficLightCycles[i].trafficLights[j].EnableRedLight();
            }
        }
    }

    IEnumerator StartTrafficLightCycles()
    {
        while (true)
        {
            for (int i = 0; i < trafficLightCycles.Length; i++)
            {
                for (int j = 0; j < trafficLightCycles[i].trafficLights.Length; j++)
                {
                    trafficLightCycles[i].trafficLights[j].EnableGreenLight();
                }
                yield return new WaitForSeconds(trafficLightCycles[i].greenTimer);

                for (int j = 0; j < trafficLightCycles[i].trafficLights.Length; j++)
                {
                    trafficLightCycles[i].trafficLights[j].EnableYellowLight();
                }
                yield return new WaitForSeconds(trafficLightCycles[i].yellowTimer);

                for (int j = 0; j < trafficLightCycles[i].trafficLights.Length; j++)
                {
                    trafficLightCycles[i].trafficLights[j].EnableRedLight();
                }
                yield return new WaitForSeconds(trafficLightCycles[i].redtimer);
            }
        }
    }

    IEnumerator StartTrafficLightCycle()
    {
        for (int i = 0; i < trafficLightCycles.Length; i++)
        {
            TrafficLightState[] previousState = new TrafficLightState[trafficLightCycles[i].trafficLights.Length];
            for (int j = 0; j < trafficLightCycles[i].trafficLights.Length; j++)
            {
                previousState[j] = trafficLightCycles[i].trafficLights[j].State;
            }

            for (int j = 0; j < trafficLightCycles[i].trafficLights.Length; j++)
            {
                trafficLightCycles[i].trafficLights[j].EnableYellowLight();
            }
            yield return new WaitForSeconds(trafficLightCycles[i].yellowTimer);

            for (int j = 0; j < trafficLightCycles[i].trafficLights.Length; j++)
            {
                if (previousState[j] == TrafficLightState.GreenState)
                    trafficLightCycles[i].trafficLights[j].EnableRedLight();
                else if (previousState[j] == TrafficLightState.RedState)
                    trafficLightCycles[i].trafficLights[j].EnableGreenLight();
            }
        }
    }
}
