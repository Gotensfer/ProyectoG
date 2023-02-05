using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halfmoon : BaseWeapon
{
    [SerializeField] GameObject HalfmoonProyectilePrefab;
    public float lifeTime = 1f;

    protected override void Awake()
    {
        base.Awake();
        StartCoroutine(UseWeapon());
    }

    IEnumerator UseWeapon()
    {
        while (true)
        {
            yield return new WaitForSeconds(cdTime);
            target = aim.GetClosestEnemy();

            if (target != null)
            {
                GameObject newProyectile = Instantiate(HalfmoonProyectilePrefab, transform.position, Quaternion.identity, aim.proyectileHierarchyContainer);
                GameObject newProyectile2 = Instantiate(HalfmoonProyectilePrefab, transform.position, Quaternion.identity, aim.proyectileHierarchyContainer);
                GameObject newProyectile2 = Instantiate(HalfmoonProyectilePrefab, transform.position, Quaternion.identity, aim.proyectileHierarchyContainer);
                GameObject newProyectile3 = Instantiate(HalfmoonProyectilePrefab, transform.position, Quaternion.identity, aim.proyectileHierarchyContainer);
                
                newProyectile.GetComponent<StraightProyectile>().Initialize(aim.GetAimDirection(transform, target), lifeTime);
                newProyectile2.GetComponent<StraightProyectile>().Initialize(aim.GetAimDirection(transform, target), lifeTime);
                newProyectile3.GetComponent<StraightProyectile>().Initialize(aim.GetAimDirection(transform, target), lifeTime);
            }

            target = null;
        }
    }
}
