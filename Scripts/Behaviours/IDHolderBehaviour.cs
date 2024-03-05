using UnityEngine;
using UnityEngine.Events;

public class IDHolderBehaviour : MonoBehaviour
{
    public ID idObj;
    public UnityEvent startEvent;

    void Start()
    {
        startEvent.Invoke();
    }
}
