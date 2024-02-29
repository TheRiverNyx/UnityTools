using System;
using System.Collections;
using System.Collections.Generic;
using Tools.Scripts.Scriptable_Objects;
using UnityEditor.U2D.Sprites;
using UnityEngine;
using UnityEngine.Events;

public class CoroutineBehaviour : MonoBehaviour
{
   public UnityEvent startEvent,startCountEvent,repeatCountEvent,endCountEvent,RepeatUntilFalseEvent;
   public bool canRun;
   public IntDataScriptableObject counterNum;
   public float seconds;
   private WaitForSeconds wfsObj;
   private WaitForFixedUpdate wffuOnj;

   private void Start()
   {
      wfsObj = new WaitForSeconds(seconds);
      wffuOnj = new WaitForFixedUpdate();
      startEvent.Invoke();
   }

   public void StartCounting()
   {
      StartCoroutine(Counting());
   }
   IEnumerator Counting()
   {
      startCountEvent.Invoke();
      while (counterNum.value > 0)
      {
         repeatCountEvent.Invoke();
         counterNum.value--;
         yield return wfsObj;
      }
      endCountEvent.Invoke();
   }

   public void StartRepeatUntilFalse()
   {
      canRun = true;
      StartCoroutine(RepeatUntilFalse());
   }
   private IEnumerator RepeatUntilFalse()
   {
      while (canRun)
      {
         yield return wfsObj;
         RepeatUntilFalseEvent.Invoke();
      }
   }
}
