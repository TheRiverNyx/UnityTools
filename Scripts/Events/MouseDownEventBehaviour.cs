using UnityEngine;
using UnityEngine.Events;

public class MouseDownEventBehaviour : MonoBehaviour
{
    public UnityEvent mouseDownEvent;

    private void OnMouseDown()
    {
        mouseDownEvent.Invoke();
    }
}
