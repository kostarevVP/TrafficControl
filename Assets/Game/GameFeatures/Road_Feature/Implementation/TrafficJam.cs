using Lukomor.Extentions;
using System.Collections.Generic;
using UnityEngine;
using VavilichevGD.Utils.Timing;

public class TrafficJam : MonoBehaviour
{
    [SerializeField] private TimerType _timerType;
    [SerializeField] private float _remainingSeconds;
    [SerializeField] private int _countCarForJamm = 4;
    private SyncedTimer _timer;

    private List<CarCoolDownSignal> _carCoolDownSignals = new List<CarCoolDownSignal>();


    private void Start()
    {
        _timer = new SyncedTimer(_timerType, _remainingSeconds);
        _timer.TimerFinished += SetFeedbackTrafficJam;
    }

    private void OnDestroy()
    {
        _timer.TimerFinished -= SetFeedbackTrafficJam;

    }

    private void SetFeedbackTrafficJam()
    {
        foreach (var car in _carCoolDownSignals)
        {
            car.IsOnJam = true;
            car.SetFeedbackTrafficJam();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CarCoolDownSignal>(out var car))
            _carCoolDownSignals.Add(car);

        if (_carCoolDownSignals.Count > _countCarForJamm )
            _timer.Start(_remainingSeconds);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<CarCoolDownSignal>(out var car))
        {
            _carCoolDownSignals.Remove(car);
            car.IsOnJam = false;
        }

        if (_carCoolDownSignals.Count < _countCarForJamm)
            _timer.Stop();
    }
}
