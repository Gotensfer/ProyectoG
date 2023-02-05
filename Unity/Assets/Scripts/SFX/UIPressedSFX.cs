using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPressedSFX : MonoBehaviour
{
    private FMOD.Studio.EventInstance pressInstance;
    [SerializeField] string fmodEvent;
    // Start is called before the first frame update
    void Start()
    {
        pressInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
    }

    public void Hold()
    {
        pressInstance.start();
    }
}
