using UnityEngine;

namespace Tools.Scripts.Scriptable_Objects
{
    [CreateAssetMenu(fileName = "Bool Data", menuName = "Scriptable Objects/Bool Data")]
    public class BoolDataScriptableObject : ScriptableObject
    {
        public bool value;

        public void UpdateValue(bool newBool)
        {
            value = newBool;
        }

        public void ToggleValue()
        {
            value = !value;
        }

        public bool ReturnValue()
        {
            return value;
        }
        
    }
}
