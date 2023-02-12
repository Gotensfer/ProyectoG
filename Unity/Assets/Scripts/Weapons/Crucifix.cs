using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crucifix : BaseWeapon
{
    [SerializeField] GameObject CrucifixProyectilePrefab;
    [SerializeField] GameObject ChristianSign;
    
    private FMOD.Studio.EventInstance cruixInstance;
    public string fmodEvent;

    public float lifeTime = 1f;

    protected override void Awake()
    {
        base.Awake();
        StartCoroutine(UseWeapon());
        cruixInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
    }

    IEnumerator UseWeapon()
    {
        while (true)
        {
            yield return new WaitForSeconds(cdTime);
            target = aim.GetClosestEnemy();

            if (target != null)
            {
                Destroy(Instantiate(ChristianSign, transform.parent.position + (Vector3.up * 1.5f), Quaternion.identity, transform.parent), 1f);

                Vector2 aimDirection = aim.GetAimDirection(transform.parent, target);

                for (int i = 0; i < 3; i++)
                {
                    GameObject newProyectile = Instantiate(CrucifixProyectilePrefab, transform.parent.position, Quaternion.identity, aim.proyectileHierarchyContainer);
                    newProyectile.GetComponent<StraightProyectile>().Initialize(aimDirection, lifeTime);
                    cruixInstance.start();

                    yield return new WaitForSeconds(0.25f);
                }
            }

            target = null;
        }
    }
}
