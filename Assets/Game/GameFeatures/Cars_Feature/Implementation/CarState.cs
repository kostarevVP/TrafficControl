using System;
using UnityEngine;

public class CarState : MonoBehaviour
{
    [field: SerializeField] public bool IsOnCross {get; private set;}

    internal void SetCarOnCross()
    {
        IsOnCross = true;
    }

    internal void SetCarOutCross()
    {
        IsOnCross = false;
    }
}
