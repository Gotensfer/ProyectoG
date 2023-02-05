using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSFX : MonoBehaviour
{
    private FMOD.Studio.EventInstance dieInstance;
    [SerializeField] string fmodEvent;
    // Start is called before the first frame update
    void Start()
    {
        dieInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
    }

    public void Die()
    {
        dieInstance.start();
    }
}
