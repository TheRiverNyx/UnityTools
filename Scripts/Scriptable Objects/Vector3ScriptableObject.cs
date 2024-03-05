using UnityEngine;

namespace Tools.Scripts.Scriptable_Objects
{
    [CreateAssetMenu(fileName = "vector 3 Data", menuName = "Scriptable Objects/Vector3Data")]
    public class Vector3ScriptableObject : ScriptableObject
    {
        public Vector3 value;

        public void UpdateValue(float x, float y, float z)
        {
            value.x += x;
            value.y += y;
            value.z += z;
        }
        public void SetValue(float x, float y, float z)
        {
            value.x = x;
            value.y = y;
            value.z = z;
        }
        public void ResetValue()
        {
            value = Vector3.zero;
        }
        public Vector3 GetValue()
        {
            return value;
        }
        public void MultiplyValue(float x, float y, float z)
        {
            value.x *= x;
            value.y *= y;
            value.z *= z;
        }
    }
}
