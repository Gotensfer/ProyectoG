using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : BaseWeapon
{
    [SerializeField] GameObject shieldProyectilePrefab;
    [SerializeField] float orbitRadius = 3;
    [SerializeField] float orbitSpeed = 2;
    public float shieldLifetime = 2;
    
    private FMOD.Studio.EventInstance shieldInstance;
    public string fmodEvent;

    protected override void Awake()
    {
        base.Awake();
        StartCoroutine(UseWeapon());
        shieldInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
    }

    IEnumerator UseWeapon()
    {
        while (true)
        {
            yield return new WaitForSeconds(cdTime);
            target = aim.GetClosestEnemy();

            if (target != null)
            {
                GameObject newProyectile = Instantiate(shieldProyectilePrefab, transform.position, Quaternion.identity, aim.proyectileHierarchyContainer);
                newProyectile.GetComponent<OrbitProyectile>().Initialize(orbitSpeed, orbitRadius, transform.parent, shieldLifetime);
                shieldInstance.start();
            }

            target = null;
        }
    }
}
