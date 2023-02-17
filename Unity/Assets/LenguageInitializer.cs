using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LenguageInitializer : MonoBehaviour
{
    void Start()
    {
        ChangeLanguage.Language = 1;
        switch (Application.systemLanguage)
        {
            case SystemLanguage.English:
                ChangeLanguage.Language = 0;
                break;
            case SystemLanguage.Spanish:
                ChangeLanguage.Language= 1;
                break;

            default:
                ChangeLanguage.Language = 0;
                break;
        }
    }
}
