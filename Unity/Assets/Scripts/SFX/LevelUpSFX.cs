using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSFX : MonoBehaviour
{
    private FMOD.Studio.EventInstance levelUpInstance;
    [SerializeField] string fmodEvent;
    // Start is called before the first frame update
    void Start()
    {
        levelUpInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
    }

    public void LevelUp()
    {
        levelUpInstance.start();
    }
}
