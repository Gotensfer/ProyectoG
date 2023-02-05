using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHoldSFX : MonoBehaviour
{
    private FMOD.Studio.EventInstance holdInstance;
    [SerializeField] string fmodEvent;
    // Start is called before the first frame update
    void Start()
    {
        holdInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
    }

    public void Hold()
    {
        holdInstance.start();
    }
}
