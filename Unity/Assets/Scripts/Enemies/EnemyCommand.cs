using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCommand : MonoBehaviour
{
    [SerializeField] Transform playerReference;

    public static Transform player;
    public static Vector2 playerPos;

    private void Start()
    {
        if (playerReference == null)
        {
            Debug.LogError("|EnemyCommand| No se asignó la referencia del jugador.");
        }
        player = playerReference;
    }

    private void Update()
    {
        playerPos = player.position;
    }
}
