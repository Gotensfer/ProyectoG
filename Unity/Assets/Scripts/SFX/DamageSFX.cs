using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSFX : MonoBehaviour
{
    private FMOD.Studio.EventInstance hitInstance;
    [SerializeField] string fmodEvent;
    // Start is called before the first frame update
    void Start()
    {
        hitInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
    }

    public void Hit()
    {
        hitInstance.start();
    }
}
