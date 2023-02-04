using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Age
{
    Primitive = 0,
    Ancient = 1,
    Medieval = 2,
    Modern = 3,
    Contemporary = 4
}

public class AgeManager : MonoBehaviour
{
    public static Age age = Age.Primitive;

    [SerializeField] GameObject[] weaponsAtAge;
    [SerializeField] Transform player;

    public static UnityEvent onAgeChange = new();

    private void Start()
    {
        age = Age.Primitive;
        onAgeChange.AddListener(SetAgeWeapon);
    }

    void SetAgeWeapon()
    {
        Instantiate(weaponsAtAge[(int)age], Vector3.zero, Quaternion.identity, player);
    }
}
