using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halfmoon : BaseWeapon
{
    [SerializeField] GameObject HalfmoonProyectilePrefab;
    [SerializeField] GameObject IslamSign;

    public float lifeTime = 1f;

    private FMOD.Studio.EventInstance islamInstance;
    public string fmodEvent;


    protected override void Awake()
    {
        base.Awake();
        StartCoroutine(UseWeapon());
        islamInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
    }

    IEnumerator UseWeapon()
    {
        while (true)
        {
            yield return new WaitForSeconds(cdTime);
            target = aim.GetClosestEnemy();

            if (target != null)
            {
                //GameObject newProyectile = Instantiate(HalfmoonProyectilePrefab, transform.position, Quaternion.identity, aim.proyectileHierarchyContainer);
                //GameObject newProyectile2 = Instantiate(HalfmoonProyectilePrefab, transform.position, Quaternion.identity, aim.proyectileHierarchyContainer);
                //GameObject newProyectile3 = Instantiate(HalfmoonProyectilePrefab, transform.position, Quaternion.identity, aim.proyectileHierarchyContainer);

                //newProyectile.GetComponent<StraightProyectile>().Initialize(aim.GetAimDirection(transform, target), lifeTime);
                //newProyectile2.GetComponent<StraightProyectile>().Initialize(aim.GetAimDirection(transform, target), lifeTime);
                //newProyectile3.GetComponent<StraightProyectile>().Initialize(aim.GetAimDirection(transform, target), lifeTime);

                Destroy(Instantiate(IslamSign, transform.parent.position + (Vector3.up * 1.5f), Quaternion.identity, transform.parent), 1f);

                for (int i = 0; i < 3; i++)
                {
                    GameObject newProyectile = Instantiate(HalfmoonProyectilePrefab, transform.parent.position,Quaternion.identity, aim.proyectileHierarchyContainer);
                    newProyectile.GetComponent<StraightProyectile>().Initialize(aim.GetAimDirection(transform.parent, target), lifeTime);
                    islamInstance.start();
                }
            }

            target = null;
        }
    }
}
