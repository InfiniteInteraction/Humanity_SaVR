using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ESpawner : MonoBehaviour
{
    
    public int currentRound;
    public GameObject[] spawners;  
    private bool isRoundOver;

    //Spawners area 
    public int totalToSpawn = 40;
    public GameObject enemyPrefab;
    public GameObject enemyGreenPrefab;
    public int killCount;
    public int killCountMax = 20;
    //Spawners Area

    public float enemySpeed = 3.5f;

    void Start()
    {
        GameManager.gameManager.DifficultySetting();
        InvokeRepeating("DoSpawn", GameManager.gameManager.spawnTime, GameManager.gameManager.repeatTime);
        enemySpeed = GameManager.gameManager.eSpeed;
    }

    //Spawners Area Begin//
    public void Spawn(int _totalToSpawn)
    {
        totalToSpawn = _totalToSpawn;
    }

    public void DoSpawn()
    { 
        GameObject enemy = Instantiate(enemyPrefab, spawners[Random.Range(0, spawners.Length)].transform.position, Quaternion.identity);
        enemy.GetComponent<NavMeshAgent>().speed = enemySpeed;
        SpawnCount();
    }

    public void SpawnCount()
    {
        if (totalToSpawn <= 0)
        {
            CancelInvoke();
            GameManager.gameManager.levelOver = true;
            Invoke("GetStarCalc", 5);
            
        }
    }

    public void SpawnGreen()
    {
        if (killCount == killCountMax)
        {
            Instantiate(enemyGreenPrefab, spawners[Random.Range(0, spawners.Length)].transform.position, Quaternion.identity);
            killCount = 0;
        }
    }
    void GetStarCalc()
    {
        GameManager.gameManager.Starsystem();
    }
}




