using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Spawners : MonoBehaviour
//{
//    private int totalToSpawn;
//    public GameObject enemyPrefab;
//    public GameObject enemyGreenPrefab;

//    public int killCount;
//    public int killCountMax = 20;
//    public GameObject[] spawnPoints;

//    public ESpawner roundManager;

//    public void Spawn(int _totalToSpawn)
//    {
//        totalToSpawn = _totalToSpawn;
//        InvokeRepeating("DoSpawn", 0.5f, 1.5f);
//    }

//    private void DoSpawn()
//    {
//        GameObject go = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
//        go.GetComponent<EnemyC>().Init(roundManager);
//        totalToSpawn -= 1;
//        CheckCount();
//    }

//    private void CheckCount()
//    {
//        if (totalToSpawn == 0)
//        {
//            StopSpawn();
//        }
//    }

//    private void StopSpawn()
//    {
//        CancelInvoke();
//    }

//    public void SpawnGreen()
//    {
//        if (killCount == killCountMax)
//        {
//            Instantiate(enemyGreenPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
//            killCount = 0;
//        }
//    } 
//}