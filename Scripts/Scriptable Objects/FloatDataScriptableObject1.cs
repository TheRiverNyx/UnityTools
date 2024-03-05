using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Float Data", menuName = "Scriptable Objects/Float Data")]
public class FloatDataScriptableObject : ScriptableObject
{
    public float value;

    public void UpdateValue(float num)
    {
        value += num;
    }

    public void ReplaceValue(float num)
    {
        value = num;
    }

    public void DisplayValue(Text text)
    {
        text.text = value.ToString(CultureInfo.InvariantCulture);
    }

    public float GetValue()
    {
        return value;
    }

    public void MultiplyValue(float num)
    {
        value *= num;
    }

    public void SubtractValue(float num)
    {
        value -= num;
    }

    public void ResetValue()
    {
        value = 0;
    }
}