using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
