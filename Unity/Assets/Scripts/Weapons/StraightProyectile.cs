using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightProyectile : BaseProyectile
{
    [SerializeField] float speed = 1;
    Vector2 movementDirection;
    float lifeTime = 1f;

    private void FixedUpdate()
    {
        Vector2 currentPos = transform.position;
        Vector2 movementVector = speed * Time.fixedDeltaTime * movementDirection;
        rb.MovePosition(currentPos + movementVector);
    }

    public void Initialize(Vector2 fireDirection, float lifeTime)
    {
        movementDirection = fireDirection;
        this.lifeTime = lifeTime;

        Invoke(nameof(SelfDestruct), lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BaseEnemy>() != null)
        {
            collision.GetComponent<BaseEnemy>().ReceiveDamage(damage);
            Destroy(gameObject);
        }
    }

    void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
