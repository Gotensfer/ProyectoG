using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitProyectile : BaseProyectile
{
    Transform orbitCenter;
    float orbitSpeed = 1f;
    float orbitRadius = 1f;
    float lifeTime = 1f;

    float timeAngleOffset;

    protected override void Awake()
    {
        base.Awake();
        timeAngleOffset = Random.Range(0, 10);
    }

    private void FixedUpdate()
    {
        float angle = (Time.time - timeAngleOffset) * orbitSpeed;

        float x = Mathf.Cos(angle) * orbitRadius + orbitCenter.position.x;
        float y = Mathf.Sin(angle) * orbitRadius + orbitCenter.position.y;

        rb.MovePosition(new Vector2(x, y));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BaseEnemy>() != null)
        {
            collision.GetComponent<BaseEnemy>().ReceiveDamage(damage);
        }
    }

    public void Initialize(float orbitSpeed, float orbitRadius, Transform orbitCenter, float lifeTime)
    {
        this.orbitRadius= orbitRadius;
        this.orbitSpeed = orbitSpeed;
        this.orbitCenter = orbitCenter;
        this.lifeTime= lifeTime;

        Invoke(nameof(SelfDestruct), lifeTime);
    }

    void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
