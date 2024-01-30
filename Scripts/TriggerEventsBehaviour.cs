using System;
using System.Collections;
using System.Collections.Generic;
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
