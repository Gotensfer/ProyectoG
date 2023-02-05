using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCommand : MonoBehaviour
{
    [SerializeField] Transform playerReference;
    [SerializeField] GameObject xpPrefab;

    public static Transform player;
    public static Vector2 playerPos;
    public static GameObject xpCollectible;

    private void Start()
    {
        if (playerReference == null) Debug.LogError("|EnemyCommand| No se asignó la referencia del jugador.");
        if (xpPrefab == null) Debug.LogError("|EnemyCommand| No se asignó el prefab de experiencia.");

        player = playerReference;
        xpCollectible = xpPrefab;
    }

    private void Update()
    {
        playerPos = player.position;
    }
}
