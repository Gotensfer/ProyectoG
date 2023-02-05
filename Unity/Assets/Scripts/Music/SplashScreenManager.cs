using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.Video;

public class SplashScreenManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer splashScreen;

    private bool flag = false;

    void Update()
    {
        if (!flag)
        {
            Invoke("PlayVideo", 0.05f);
            flag = true;
        }
    }

    void PlaySound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Music/SplashScreen");
    }

    void PlayVideo()
    {
        splashScreen.Play();
        PlaySound();
    }
}
