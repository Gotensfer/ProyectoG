using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected float cdTime = 1;
    public float CdTime { get => cdTime; set { cdTime = value;} }

    [SerializeField] protected int damage = 1;
    public int Damage { get => damage; set { damage = value;} }

    protected Transform target;
    protected AimAssistant aim;

    protected virtual void Awake()
    {
        aim = GetComponentInParent<AimAssistant>();

        if (aim == null)
        {
            Debug.Log($"|BaseWeapon - {name}| No se consiguió la referencia al AimAssistant, ¿Si está en el jugador?");
        }
    }
}
