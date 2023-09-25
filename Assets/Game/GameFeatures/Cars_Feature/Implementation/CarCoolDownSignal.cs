using Lukomor.Extentions;
using System.Collections;
using UnityEngine;

public class CarCoolDownSignal : MonoBehaviour
{
    [field: SerializeField] public bool IsOnJam { get;set; }

    [SerializeField] private float _waitaForSecondFrom = 1f;
    [SerializeField] private float _waitaForSecondTo = 5f;
    
    public void SetFeedbackTrafficJam()
    {
        StartCoroutine(FeedbackTrafficJam());
    }
    private void Start()
    {
        Log.PrintColor("Spawn car on start", Color.cyan);
    }
    private IEnumerator FeedbackTrafficJam()
    {
        while(IsOnJam)
        {
            yield return new WaitForSeconds(Random.Range(_waitaForSecondFrom, _waitaForSecondTo));
            Log.PrintWarning($"Car{gameObject.name} is signal to get some ride ");
            Log.PrintColor("Move motherfucker!!!", Color.cyan);
        }
    }
}
