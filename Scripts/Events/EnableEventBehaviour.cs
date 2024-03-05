using UnityEngine;
using UnityEngine.Events;

public class EnableEventBehaviour : MonoBehaviour
{
    public UnityEvent enableEvent;

    private void OnEnable()
    {
        enableEvent.Invoke();
    }
}
