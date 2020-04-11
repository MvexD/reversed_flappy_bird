using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject Coins;
    public float secoundsBetweenSpawns = 0.3f;
    float nextSpawnTime;
    public Vector3 PlayerBird;
    Transform player;
    public float igrekxD;

    Vector2 screenHalfWorldUnits;

    // Use this for initialization
    void Start()
    {
        igrekxD = 0;
        GameObject player_pos = GameObject.FindGameObjectWithTag("Player");
        screenHalfWorldUnits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        player = player_pos.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            igrekxD += 0.6f;
            nextSpawnTime = Time.time + secoundsBetweenSpawns;
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfWorldUnits.x + 0.2f, screenHalfWorldUnits.x - 0.2f), igrekxD);
            //Vector2 spawnPosition = new Vector3(Random.Range(-player.position.x -0.2f, player.position.x + 0.2f), igrekxD);
            Instantiate(Coins, spawnPosition, Quaternion.identity);
        }

    }
}
