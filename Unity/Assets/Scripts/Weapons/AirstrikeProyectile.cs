using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirstrikeProyectile : BaseProyectile
{
    [SerializeField] float speed = 1;
    Vector2 endPosition;
    float lifeTime = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BaseEnemy>() != null)
        {
            collision.GetComponent<BaseEnemy>().ReceiveDamage(damage);
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Destroy(gameObject,3f);
        }
    }

}
