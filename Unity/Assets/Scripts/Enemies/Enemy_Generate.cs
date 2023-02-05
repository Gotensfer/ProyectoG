using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy_Generate : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    //private float Ply_minX, Ply_maxX, Ply_minY, Ply_maxY;
    private Transform player;
    [SerializeField] Transform parent;

    //[SerializeField] public Transform player;
    [SerializeField] private GameObject[] enemys_primit;
    [SerializeField] private GameObject[] enemys_antigua;
    [SerializeField] private GameObject[] enemys_media;
    [SerializeField] private GameObject[] enemys_moderna;
    [SerializeField] private float enemy_time, offset = 30;
    private float next_enemy_time;
    //Vector2 player_posi;
    // Start is called before the first frame update

    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        next_enemy_time += Time.deltaTime;

        if (next_enemy_time >= enemy_time)

        {
            next_enemy_time = 0;
            Generate();
        }
    }



    private void Generate()
    {
        switch (AgeManager.age)
        {
            case Age.Primitive:
                int enenemyOn_battel = Random.Range(0, enemys_primit.Length);
                Vector2 spawnPosition = SafePosToSpawn();

                Instantiate(enemys_primit[enenemyOn_battel], spawnPosition, Quaternion.identity, parent);
                break;
            case Age.Ancient:
                int enenemyOn_battel2 = Random.Range(0, enemys_antigua.Length);
                Vector2 spawnPosition2 = SafePosToSpawn();

                Instantiate(enemys_antigua[enenemyOn_battel2], spawnPosition2, Quaternion.identity, parent);
                break;
            case Age.Medieval:
                int enenemyOn_battel3 = Random.Range(0, enemys_media.Length);
                Vector2 spawnPosition3 = SafePosToSpawn();

                Instantiate(enemys_media[enenemyOn_battel3], spawnPosition3, Quaternion.identity, parent);
                break;
            case Age.Modern:
                int enenemyOn_battel4 = Random.Range(0, enemys_moderna.Length);
                Vector2 spawnPosition4 = SafePosToSpawn();

                Instantiate(enemys_moderna[enenemyOn_battel4], spawnPosition4, Quaternion.identity, parent);
                break;
        }
    }

    Vector2 SafePosToSpawn()
    {
        int num = Random.Range(1, 5);
        Vector2 result = Vector2.zero;
        switch (num)
        {
            case 1:
                result = new Vector2(Random.Range(player.position.x - offset, player.position.x + offset), Random.Range(player.position.y + 20, player.position.y + offset));
                break;
            case 2:
                result = new Vector2(Random.Range(player.position.x - offset, player.position.x + offset), Random.Range(player.position.y - 20, player.position.y - offset));
                break;
            case 3:
                result = new Vector2(Random.Range(player.position.x + 20, player.position.x + offset), Random.Range(player.position.y - offset, player.position.y + offset));
                break;
            case 4:
                result = new Vector2(Random.Range(player.position.x - offset, player.position.x - 20), Random.Range(player.position.y - offset, player.position.y + offset)); break;
        }

        return result;
    }

}