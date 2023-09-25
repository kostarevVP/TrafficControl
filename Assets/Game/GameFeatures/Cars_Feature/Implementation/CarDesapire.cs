using Lukomor.Extentions;
using TurnTheGameOn.SimpleTrafficSystem;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarDesapire : MonoBehaviour, IPointerClickHandler
{
    private AITrafficCar _car;
    private CarState _state;

    void Start()
    {
        if (TryGetComponent<AITrafficCar>(out var car))
            _car = car;
        else
            Log.PrintWarning("Cant find AITrafficCar component on gameObject");


        if (TryGetComponent<CarState>(out var state))
            _state = state;
        else
            Log.PrintWarning("Cant find CarState component on gameObject");

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Log.PrintWarning($"OnPointerClick detect ");
        if (_state.IsOnCross)
            _car.MoveCarToPool();
        else
            Log.PrintWarning("Car not on cross yet");
    }
}
