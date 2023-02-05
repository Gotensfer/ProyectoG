using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BaseProyectile : MonoBehaviour
{
    [SerializeField] protected int damage = 1;
    public int Damage { get => damage; }

    protected Rigidbody2D rb;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
