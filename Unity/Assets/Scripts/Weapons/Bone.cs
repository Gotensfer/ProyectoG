using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : BaseWeapon
{
    [SerializeField] GameObject boneProyectilePrefab;
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
                GameObject newProyectile = Instantiate(boneProyectilePrefab, transform.parent.position, Quaternion.identity, aim.proyectileHierarchyContainer);
                newProyectile.GetComponent<StraightProyectile>().Initialize(aim.GetAimDirection(transform.parent, target), lifeTime);
            }

            target = null;
        }
    }
}
