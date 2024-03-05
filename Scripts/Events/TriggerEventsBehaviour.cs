using UnityEngine;
using UnityEngine.Events;

public class TriggerEventsBehaviour : MonoBehaviour
{
    public UnityEvent triggerEnterBehaviour;

    private void OnTriggerEnter(Collider other)
    {
        triggerEnterBehaviour.Invoke();
    }
}
