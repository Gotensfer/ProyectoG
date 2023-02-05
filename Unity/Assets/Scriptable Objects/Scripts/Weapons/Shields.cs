using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : BaseWeapon
{
    [SerializeField] GameObject shieldProyectilePrefab;
    [SerializeField] float orbitRadius = 3;
    [SerializeField] float orbitSpeed = 2;
    public float shieldLifetime = 2;

    protected override void Awake()
    {
        base.Awake();
        StartCoroutine(UseWeapon());
        AgeManager.onAgeChange.AddListener(DeleteSelf);
    }

    void DeleteSelf()
    {
        AgeManager.onAgeChange.RemoveListener(DeleteSelf);
        Destroy(gameObject);
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
                newProyectile.GetComponent<OrbitProyectile>().Initialize(orbitSpeed, orbitRadius, transform, shieldLifetime);
            }

            target = null;
        }
    }
}
