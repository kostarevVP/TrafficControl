using System;
using UnityEngine;

public class CarSpeedometer : MonoBehaviour
{
    public Action OnCarStopedEvent;
    public float Speed;
    public bool IsMoving => Speed < 0.1;

    private Rigidbody _rbCar;
    

    private void Start()
    {
        _rbCar = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        Speed = _rbCar.velocity.magnitude;
        if(!IsMoving )
        {
            OnCarStopedEvent?.Invoke();
        }
    }
}

