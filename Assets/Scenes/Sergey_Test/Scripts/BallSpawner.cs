using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    GameObject prefab;
    Transform spawnPoint;
    bool spawnNow = true;

    private void Awake()
    {
        prefab = Resources.Load(("Prefabs/Alien"), typeof(GameObject)) as GameObject;
        spawnPoint = GetComponentInChildren<ID_BallSpawn>().transform;
    }

    private void Update()
    {
        if (spawnNow)
        {
            StartCoroutine("SpawnBalls");
        }
    }

    IEnumerator SpawnBalls()
    {
        spawnNow = false;
        Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(5f);
        spawnNow = true;
    }
}
