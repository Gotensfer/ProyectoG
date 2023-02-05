using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeEnemy : BaseEnemy
{
    protected override void InflictContactDamage(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerVitals>().ReceiveDamage(baseDamage);
            Destroy(gameObject);
        }
    }
}
