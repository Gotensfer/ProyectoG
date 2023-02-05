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
}

public enum GamePath
{
    Main = 0,
    Secondary = 1
}

public class AgeManager : MonoBehaviour
{
    public static Age age = Age.Primitive;
    public static GamePath path = GamePath.Main;    

    [SerializeField] Transform player;
    [SerializeField] GameObject primitiveWeapon, ancientMain, ancientSecondary, medievalMain, medievalSecondary, 
        modernMain, modernSecondary;

    public static UnityEvent onAgeChange = new();

    private void Start()
    {
        age = Age.Primitive;
    }

    public void ChooseMainPath()
    {
        path = GamePath.Main;
    }

    public void ChooseSecondaryPath()
    {
        path = GamePath.Secondary;
    }

    public void ProvideWeapon()
    {
        SetAgeWeapon();
    }

    void SetAgeWeapon()
    {
        switch (age)
        {
            case Age.Primitive:
                AddWeaponToPlayer(primitiveWeapon);
                break;
            case Age.Ancient:
                if (path == GamePath.Main) AddWeaponToPlayer(ancientMain);
                else AddWeaponToPlayer(ancientSecondary);
                break;
            case Age.Medieval:
                if (path == GamePath.Main) AddWeaponToPlayer(medievalMain);
                else AddWeaponToPlayer(medievalSecondary);
                break;
            case Age.Modern:
                if (path == GamePath.Main) AddWeaponToPlayer(modernMain);
                else AddWeaponToPlayer(modernSecondary);
                break;
        }
    }

    void AddWeaponToPlayer(GameObject weapon)
    {
        Instantiate(weapon, Vector3.zero, Quaternion.identity, player);
    }
}
