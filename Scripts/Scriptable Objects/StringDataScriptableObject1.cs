using UnityEngine;

namespace Tools.Scripts.Scriptable_Objects
{
    [CreateAssetMenu(fileName = "String Data", menuName = "ScriptableObjects/String Data")]
    public class StringDataScriptableObject : ScriptableObject
    {
        public string value;

        public void SetValue(string text)
        {
            value = text;
        }

        public void ResetValue()
        {
            value = "";
        }

        public void Concatenate(string text)
        {
            value += text;
        }

        public string ReturnValue()
        {
            return value;
        }

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(value);
        }
    }
}