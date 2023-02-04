using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AimAssistant : MonoBehaviour
{
    public Transform proyectileHierarchyContainer;

    [SerializeField] float aimRange = 10;

    [SerializeField] int enemyLayerID;
    LayerMask enemyLayer;

    private void Start()
    {
        enemyLayer = LayerMask.GetMask(LayerMask.LayerToName(enemyLayerID)); 
    }

    public Transform GetClosestEnemy()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, aimRange, enemyLayer);
        Transform nearestTarget = null;

        int len = targets.Length;
        float closestDistance = 1000;

        for (int i = 0; i < len; i++)
        {
            float distance = Vector3.Distance(transform.position, targets[i].transform.position);

            if (distance < closestDistance)
            {
                nearestTarget = targets[i].transform;
                closestDistance = distance;
            }
        }

        return nearestTarget;
    }

    public Transform GetFarthestEnemy()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, aimRange, enemyLayer);
        Transform farthestTarget = null;

        int len = targets.Length;
        float farthestDistance = 0;

        for (int i = 0; i < len; i++)
        {
            float distance = Vector3.Distance(transform.position, targets[i].transform.position);

            if (distance > farthestDistance)
            {
                farthestTarget = targets[i].transform;
                farthestDistance = distance;
            }
        }

        return farthestTarget;
    }

    public Transform GetRandomEnemy()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, aimRange, enemyLayer);
        Transform randomTarget = null;

        try
        {
            System.Random rnd = new System.Random();
            randomTarget = targets.OrderBy(x => rnd.Next()).Take(1).ElementAt(0).transform;
        }
        catch (Exception)
        {
            randomTarget = null;
        }

        return randomTarget;
    }

    public Vector2 GetAimDirection(Transform origin, Transform target)
    {
        Vector2 direction = (target.position - origin.position).normalized;
        return direction;
    }

}
