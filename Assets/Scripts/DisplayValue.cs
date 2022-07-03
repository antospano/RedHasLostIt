using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayValue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public float value;

    private void Update()
    {
        text.text = value.ToString();
    }
}
