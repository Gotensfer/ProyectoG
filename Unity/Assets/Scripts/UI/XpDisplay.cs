using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[RequireComponent(typeof(TextMeshProUGUI))]
public class XpDisplay : MonoBehaviour
{
    TextMeshProUGUI display;
    [SerializeField]PlayerVitals vitals;
    void Start()
    {
        display = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        display.text = $"{vitals.Experience * 25}%";
    }
}
