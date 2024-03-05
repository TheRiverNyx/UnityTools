using UnityEngine;
using UnityEngine.Events;

public class MonoEventBehaviour : MonoBehaviour
{
    public UnityEvent startEvent, awakeEvent, disableEvent;
    
    private void Start()
    {
        startEvent.Invoke();
    }
    private void Awake()
    {
        awakeEvent.Invoke();
    }
    private void OnDisable()
    {
        disableEvent.Invoke();
    }
}
