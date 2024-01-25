using UnityEngine;


[CreateAssetMenu(fileName = "Float Data", menuName = "ScriptableObjects/Float Data")] 
public class FloatDataScriptableObject : ScriptableObject
{

        public float value;

        public void UpdateValue(float num)
        {
                value += num;
        }
}

