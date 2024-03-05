using UnityEngine;
using UnityEngine.Events;

namespace Tools.Scripts.Scriptable_Objects
{
    [CreateAssetMenu(fileName = "Int Data", menuName = "Scriptable Objects/Int Data")]
    public class IntDataScriptableObject : ScriptableObject
    {
        public int value;
        public UnityEvent disableEvent;

        public void UpdateValue(int num)
        {
            value += num;
        }

        public void SetValue(int num)
        {
            value = num;
        }

        public void SetValueObj(IntDataScriptableObject obj)
        {
            value = obj.value;
        }

        public void CompareValue(IntDataScriptableObject obj)
        {
            if (value >= obj.value)
            {
            }
            else
            {
                value = obj.value;
            }
        }

        public int ReturnValue()
        {
            return value;
        }

        public void MuliplyValue(int num)
        {
            value *= num;
        }

        public void ResetValue()
        {
            value = 0;
        }

        private void OnDisable()
        {
            disableEvent.Invoke();
        }
    }
}
