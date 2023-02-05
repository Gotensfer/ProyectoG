using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    
    private FMOD.Studio.EventInstance musicInstance;
    int parametterSetter;
    public string fmodEvent;

    private int age = (int)AgeManager.age;
    
    // Start is called before the first frame update
    void Start()
    {
        musicInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        musicInstance.start();
    }

    public void ParametterSetter()
    {
        switch ((int)AgeManager.age)
        {
            case 0:
                break;
            case 1:
                parametterSetter = 1;
                Setter();
                break;
            case 2:
                parametterSetter = 2;
                Setter();
                break;
            case 3:
                parametterSetter = 3;
                Setter();
                break;
        }
    }
    
    void Setter()
    {
        musicInstance.setParameterByName("Age", parametterSetter);
    }
    
}
