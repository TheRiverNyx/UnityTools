using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ApplicationPauseEventBehaviour : MonoBehaviour
{
    public UnityEvent applicationPauseEvent;

    private void OnApplicationPause(bool pauseStatus)
    {
        applicationPauseEvent.Invoke();
    }
}
