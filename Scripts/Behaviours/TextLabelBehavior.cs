using System.Globalization;
using UnityEngine;
using TMPro;
using Tools.Scripts.Scriptable_Objects;
using UnityEngine.Events;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLabelBehavior : MonoBehaviour
{
    private TextMeshProUGUI label;
    public UnityEvent startEvent;

    private void Start()
    {
        label = GetComponent<TextMeshProUGUI>();
        startEvent.Invoke();
    }

    public void UpdateLabel(FloatDataScriptableObject obj)
    {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }
    public void UpdateLabel(IntDataScriptableObject obj)
    {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }
}
