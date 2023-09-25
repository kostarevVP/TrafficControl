namespace TurnTheGameOn.SimpleTrafficSystem
{
    using System;
    using UnityEngine;

    [System.Serializable]
    public enum TrafficLightState
    {
        None = 0,
        GreenState = 0,
        YellowState = 1,
        RedState = 2,
    }

    public class AITrafficLight : MonoBehaviour
    {
        public Action<TrafficLightState> OnChangeStateEvent;

        public MeshRenderer redMesh;
        public MeshRenderer yellowMesh;
        public MeshRenderer greenMesh;
        public AITrafficWaypointRoute waypointRoute;

        public TrafficLightState State { get; private set; }

        public void EnableRedLight()
        {
            if (waypointRoute) waypointRoute.StopForTrafficlight(true);
            redMesh.enabled = true;
            yellowMesh.enabled = false;
            greenMesh.enabled = false;
            State = TrafficLightState.RedState;
            OnChangeStateEvent?.Invoke(State);
        }

        public void EnableYellowLight()
        {
            if (waypointRoute) waypointRoute.StopForTrafficlight(true);
            redMesh.enabled = false;
            yellowMesh.enabled = true;
            greenMesh.enabled = false;
            State = TrafficLightState.YellowState;
            OnChangeStateEvent?.Invoke(State);
        }

        public void EnableGreenLight()
        {
            if (waypointRoute) waypointRoute.StopForTrafficlight(false);
            redMesh.enabled = false;
            yellowMesh.enabled = false;
            greenMesh.enabled = true;
            State = TrafficLightState.GreenState;
            OnChangeStateEvent?.Invoke(State);
        }

        public void DisableAllLights()
        {
            if (waypointRoute) waypointRoute.StopForTrafficlight(true);
            redMesh.enabled = false;
            yellowMesh.enabled = false;
            greenMesh.enabled = false;
            State = TrafficLightState.None;

            OnChangeStateEvent?.Invoke(State);
        }

    }
}