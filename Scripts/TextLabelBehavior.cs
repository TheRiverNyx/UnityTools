using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLabelBehavior : MonoBehaviour
{
    public TextMeshProUGUI label;
    public FloatDataScriptableObject dataObj;

    private void Start()
    {
        label = GetComponent<TextMeshProUGUI>();
        label.text = dataObj.value.ToString(CultureInfo.InvariantCulture);
        UpdateLabel();
    }

    public void UpdateLabel()
    {
        label.text = dataObj.value.ToString(CultureInfo.InvariantCulture);
    }
}
