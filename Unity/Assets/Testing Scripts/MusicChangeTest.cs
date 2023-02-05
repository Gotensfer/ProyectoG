using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class MusicChangeTest : MonoBehaviour
{
    private FMOD.Studio.EventInstance musicInstance;

    public string fmodEvent;
    
    [SerializeField] [Range(0,3)]
    int parametterSetter;
    
    // Start is called before the first frame update
    void Start()
    {
        musicInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        musicInstance.start();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)) Setter();
    }

    void Setter()
    {
        musicInstance.setParameterByName("Age", parametterSetter);
    }
}
