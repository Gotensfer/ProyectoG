using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodsWrath : BaseWeapon
{
    [SerializeField] GameObject GodsWrathProyectilePrefab;
    public float lifeTime = 1f;
    
    private FMOD.Studio.EventInstance godsInstance;
    public string fmodEvent;


    protected override void Awake()
    {
        base.Awake();
        StartCoroutine(UseWeapon());
        godsInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
    }

    IEnumerator UseWeapon()
    {
        while (true)
        {
            yield return new WaitForSeconds(cdTime);
            target = aim.GetRandomEnemy();

            if (target != null)
            {
                GameObject newProyectile = Instantiate(GodsWrathProyectilePrefab, target.position,Quaternion.identity, aim.proyectileHierarchyContainer);
                newProyectile.GetComponent<AirstrikeProyectile>();
                godsInstance.start();
            }

            target = null;
        }
    }

}
