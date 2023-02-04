using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickEnemy : BaseEnemy
{
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }
}
