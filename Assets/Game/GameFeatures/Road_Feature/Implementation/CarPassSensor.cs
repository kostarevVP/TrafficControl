using Assets.Game.Services.Progress_Service.api;
using Lukomor.Common.DIContainer;
using Lukomor.Extentions;
using UnityEngine;

public class CarPassSensor : MonoBehaviour
{
    private const string PlayerTag = "Player";

    [SerializeField] private int _scoreForCar = 1;
    private GameProgress _progress;

    private void Start()
    {
        _progress = new DIVar<IProgressService>().Value.Progress;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == PlayerTag)
        {
            _progress.CarPass(_scoreForCar, other.transform);
            Log.PrintColor($"Add score {_scoreForCar} total score = {_progress.CarPassCount}", Color.red);
        }
    }
}
