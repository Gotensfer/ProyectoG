using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEXP_SFX : MonoBehaviour
{
    private FMOD.Studio.EventInstance expInstance;
    [SerializeField] string fmodEvent;
    // Start is called before the first frame update
    void Start()
    {
        expInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
    }

    public void Add()
    {
        expInstance.start();
    }
}

