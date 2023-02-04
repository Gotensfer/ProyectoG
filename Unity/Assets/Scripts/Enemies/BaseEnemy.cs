using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected int health;
    public int Health { get => health; }

    [SerializeField] protected int maxHealth;
    public int MaxHealth { get => maxHealth; }

    [SerializeField] protected float baseSpeed;
    public float BaseSpeed { get => baseSpeed; }

    protected Rigidbody2D rb;

    public virtual void ReceiveDamage(int amount)
    {
        if (amount < 0)
        {
            Debug.LogWarning($"Se intentó agregar el valor negativo de {amount} daño.");
            return;
        }
        health = Mathf.Clamp(health - amount, 0, maxHealth);
    }

    public virtual void Move()
    {      
        Vector2 currentPos = transform.position;
        Vector2 movementVector = baseSpeed * Time.fixedDeltaTime * (EnemyCommand.playerPos - currentPos).normalized;
        rb.MovePosition(currentPos + movementVector);
    }
}
