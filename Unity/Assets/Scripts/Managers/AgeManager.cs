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

    public static UnityEvent onAgeChange;

    private void Start()
    {
        age = Age.Primitive;
    }
}
