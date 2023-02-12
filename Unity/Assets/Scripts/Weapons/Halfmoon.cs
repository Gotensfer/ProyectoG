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
                Destroy(Instantiate(IslamSign, transform.parent.position + (Vector3.up * 1.5f), Quaternion.identity, transform.parent), 1f);

                Vector2 aimDirection = aim.GetAimDirection(transform.parent, target);

                for (int i = 0; i < 3; i++)
                {
                    GameObject newProyectile = Instantiate(HalfmoonProyectilePrefab, transform.parent.position,Quaternion.identity, aim.proyectileHierarchyContainer);
                    newProyectile.GetComponent<StraightProyectile>().Initialize(aimDirection, lifeTime);
                    islamInstance.start();

                    yield return new WaitForSeconds(0.25f);
                }
            }

            target = null;
        }
    }
}
