using WKosArch.Extentions;
using UnityEngine;

public class CarCrashDetector : MonoBehaviour
{
    private Collider _carBoxCollider;


    private void Start()
    {
        _carBoxCollider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
            Log.PrintWarning($"Crash detected with {gameObject.name} and {collision.gameObject.name}");
    }

}
