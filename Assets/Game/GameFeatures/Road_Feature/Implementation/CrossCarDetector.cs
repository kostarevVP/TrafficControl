using UnityEngine;

public class CrossCarDetector : MonoBehaviour
{
    private const string CAR_TAG = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.transform.tag == CAR_TAG)
        {
            if (other.gameObject.TryGetComponent<CarState>(out var state))
                state.SetCarOnCross();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.transform.tag == CAR_TAG)
        {
            if (other.gameObject.TryGetComponent<CarState>(out var state))
                state.SetCarOutCross();
        }
    }
}
