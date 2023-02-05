using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothing : MonoBehaviour
{
    // Start is called before the first frame update

    SpriteRenderer sRenderer;
    [SerializeField] Sprite[] sprites;
    [SerializeField] private ParticleSystem ps;
    
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void SetAgeClothing()
    {
        switch (AgeManager.age)
        {
            case Age.Ancient:
                if (AgeManager.path == GamePath.Main) sRenderer.sprite = sprites[1];
                else sRenderer.sprite = sprites[2];
                
                break;
            case Age.Medieval:
                if (AgeManager.path == GamePath.Main) sRenderer.sprite = sprites[3];
                else sRenderer.sprite = sprites[4];
                
                break;
            case Age.Modern:
                if (AgeManager.path == GamePath.Main) sRenderer.sprite = sprites[5];
                else sRenderer.sprite = sprites[6];
                break;
        }
        
        ps.Play(true);
        
    }
}
