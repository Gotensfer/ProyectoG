using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected int health;
    public int Health { get => health; }

    [SerializeField] protected float baseSpeed;
    public float BaseSpeed { get => baseSpeed; }

    [SerializeField] protected int baseDamage;
    public int BaseDamage { get => baseDamage; }

    [SerializeField] protected float attackReloadTime;


    protected Rigidbody2D rb;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        InflictContactDamage(collision);
    }

    protected virtual void InflictContactDamage(Collider2D collision)
    {
        if (collision.GetComponent<PlayerVitals>() != null)
        {
            collision.GetComponent<PlayerVitals>().ReceiveDamage(baseDamage);
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(ReloadContactDamage());
        }
    }

    protected IEnumerator ReloadContactDamage()
    {
        yield return new WaitForSeconds(attackReloadTime);
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public virtual void ReceiveDamage(int amount)
    {
        if (amount < 0)
        {
            Debug.LogWarning($"Se intentó agregar el valor negativo de {amount} daño.");
            return;
        }
        health -= amount;

        if (health <= 0)
        {
            Instantiate(EnemyCommand.xpCollectible, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public virtual void Move()
    {      
        Vector2 currentPos = transform.position;
        Vector2 movementVector = baseSpeed * Time.fixedDeltaTime * (EnemyCommand.playerPos - currentPos).normalized;
        rb.MovePosition(currentPos + movementVector);
    }
}
