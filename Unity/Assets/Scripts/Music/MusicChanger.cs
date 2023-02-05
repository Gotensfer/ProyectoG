using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    
    private FMOD.Studio.EventInstance musicInstance;
    int parametterSetter;
    public string fmodEvent;
    
    //Vitals
    [SerializeField] private PlayerVitals vitals;

    // Start is called before the first frame update
    void Start()
    {
        musicInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        musicInstance.start();
        vitals.onDeath.AddListener(StopMusic);
        AgeManager.onAgeChange.AddListener((ParametterSetter));
    }

    public void ParametterSetter()
    {
        switch (AgeManager.age)
        {
            case Age.Primitive:
                break;
            case Age.Ancient:
                parametterSetter = 1;
                Setter();
                break;
            case Age.Medieval:
                parametterSetter = 2;
                Setter();
                break;
            case Age.Modern:
                parametterSetter = 3;
                Setter();
                break;
        }
    }
    
    void Setter()
    {
        musicInstance.setParameterByName("Age", parametterSetter);
    }

    void StopMusic()
    {
        musicInstance.stop(STOP_MODE.ALLOWFADEOUT);
    }
}
