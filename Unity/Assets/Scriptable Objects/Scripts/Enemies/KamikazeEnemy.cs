using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeEnemy : BaseEnemy
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void Kamikaze_action()
    {
        Destroy(this);return;
        
    }
    
}
