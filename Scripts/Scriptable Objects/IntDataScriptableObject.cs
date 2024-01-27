using UnityEngine;

namespace Tools.Scripts.Scriptable_Objects
{
    [CreateAssetMenu(fileName = "Int Data", menuName = "ScriptableObjects/Int Data")]
    public class IntDataScriptableObject : ScriptableObject
    {
        public int value;

        public void UpdateValue(int num)
        {
            value += num;
        }

        public void SetValue(int num)
        {
            value = num;
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
    }
}
