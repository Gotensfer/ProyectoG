using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : BaseWeapon
{
    [SerializeField] GameObject boneProyectilePrefab;

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
                GameObject newProyectile = Instantiate(boneProyectilePrefab, transform.position, Quaternion.identity);
                newProyectile.GetComponent<StraightProyectile>().Initialize(aim.GetAimDirection(transform, target));
            }

            target = null;
        }
    }
}
