using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TriggerEventBehavior : MonoBehaviour
{
    public UnityEvent TriggerEvent;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D other)
    {
        TriggerEvent.Invoke();
    }
}
