using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodsWrath : BaseWeapon
{
    [SerializeField] GameObject GodsWrathProyectilePrefab;
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
                GameObject newProyectile = Instantiate(GodsWrathProyectilePrefab, target.position,Quaternion.identity, aim.proyectileHierarchyContainer);
                newProyectile.GetComponent<AirstrikeProyectile>();
            }

            target = null;
        }
    }

}
