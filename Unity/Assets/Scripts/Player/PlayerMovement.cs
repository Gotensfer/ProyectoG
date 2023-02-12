using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject[] weapon;
    [SerializeField] float baseSpeed = 1;
    PlayerController controller;
    PlayerVitals viltals;
    Rigidbody2D rb;

    
    private void Start()
    {
        viltals = GetComponent<PlayerVitals>();
        controller = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
        if (viltals.isDead == false)
        {
            Move();
        }
        
    }

    void Move()
    {

        Vector2 movementVector = controller.controlAxis.normalized * baseSpeed * Time.fixedDeltaTime;
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        rb.MovePosition(currentPos + movementVector);
    }
}
