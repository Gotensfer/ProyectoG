using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Generate : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    private float Ply_minX, Ply_maxX, Ply_minY, Ply_maxY;
    [SerializeField] private Transform[] points;
    [SerializeField] private GameObject[] enemys;
    [SerializeField] public GameObject[] player;
    [SerializeField] private float enemy_time;
    private float next_enemy_time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        next_enemy_time += Time.deltaTime;

        if (next_enemy_time >= enemy_time)
        {
            

            next_enemy_time = 0;
            generator();
        }
    }

    private void generator()
    {
        int number_enemy = Random.Range(0, enemys.Length);

    }
}
