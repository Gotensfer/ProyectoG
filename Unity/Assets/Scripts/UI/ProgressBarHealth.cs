using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBarHealth : MonoBehaviour
{
    public int progress;
    public Image mask;

    [SerializeField] PlayerVitals vitals;

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        progress = vitals.Health;

        float fillAmount = (float)progress / (float)vitals.MaxHealth;
        mask.fillAmount = fillAmount;
    }
}
