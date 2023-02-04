using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AimAssistant : MonoBehaviour
{
    [SerializeField] float aimRange = 10;
    [SerializeField] int maxTargets = 64;

    [SerializeField] int enemyLayerID;
    LayerMask enemyLayer;

    private void Start()
    {
        enemyLayer = LayerMask.GetMask(LayerMask.LayerToName(enemyLayerID)); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            print(GetClosestEnemy().name);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            print(GetFarthestEnemy().name);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            print(GetRandomEnemy().name);
        }
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
        Transform nearestTarget = null;

        int len = targets.Length;
        float farthestDistance = 0;

        for (int i = 0; i < len; i++)
        {
            float distance = Vector3.Distance(transform.position, targets[i].transform.position);

            if (distance > farthestDistance)
            {
                nearestTarget = targets[i].transform;
                farthestDistance = distance;
            }
        }

        return nearestTarget;
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

}
