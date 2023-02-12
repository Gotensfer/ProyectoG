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

    [Header("Contenedores de Props para el cambio de textura")]
    [SerializeField] Transform prop1Container;
    [SerializeField] Transform prop2Container;
    [SerializeField] Transform prop3Container;
    [SerializeField] Transform prop4Container;
    [SerializeField] Transform prop5Container;
    [SerializeField] Transform backgroundContainer;
    [SerializeField] Transform enemyContainer;

    [SerializeField] Clothing clothing;

    public static UnityEvent onAgeChange = new();

    private void Start()
    {
        age = Age.Primitive;
    }

    public void ChooseMainPath()
    {
        path = GamePath.Main;
        CommonAgeOperations();
    }

    public void ChooseSecondaryPath()
    {
        path = GamePath.Secondary;
        CommonAgeOperations();
    }

    void CommonAgeOperations()
    {
        ChangeAllAgeMapTextures();
        CleanMapFromEnemies();
        ProvideWeapon();
        clothing.SetAgeClothing();
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

    void ChangeAllAgeMapTextures()
    {
        print($"{age} - {path}");

        SetTextureChangeInArray(prop1Container);
        SetTextureChangeInArray(prop2Container);
        SetTextureChangeInArray(prop3Container);
        SetTextureChangeInArray(prop4Container);
        SetTextureChangeInArray(prop5Container);
        SetTextureChangeInArray(backgroundContainer);
    }

    void SetTextureChangeInArray(Transform container)
    {
        int totalProps = container.childCount;

        for (int i = 0; i < totalProps; i++)
        {
            if (container.GetChild(i).transform.GetComponentInChildren<TextureChanger>() != null)
            {
                container.GetChild(i).transform.GetComponentInChildren<TextureChanger>().SetEraTextures();
            }            
        }
    }

    void CleanMapFromEnemies()
    {
        int totalProps = enemyContainer.childCount;

        for (int i = 0; i < totalProps; i++)
        {
            Destroy(enemyContainer.GetChild(i).transform.gameObject);
        }
    }
}
