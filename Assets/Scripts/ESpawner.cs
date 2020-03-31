using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ESpawner : MonoBehaviour
{

    public int currentRound;
    public GameObject[] spawners;
    private bool isRoundOver;
    public Health playerHealth;

    //Spawners area 
    public int totalToSpawn = 40;
    public GameObject enemyPrefab;
    public GameObject enemyGreenPrefab;

    public int streakCount;
    public int enemyCount = 10;

    public int killCount;
    public int killCountMax = 20;

    public AudioSource tenKills;



    //Spawners Area

    public float enemySpeed = 3.5f;

    void Start()
    {
        GameManager.gameManager.DifficultySetting();
        InvokeRepeating("DoSpawn", GameManager.gameManager.spawnTime, GameManager.gameManager.repeatTime);
        enemySpeed = GameManager.gameManager.eSpeed;
        enemyCount = 10;
    }

    public void KillStreak()
    {
        if (streakCount == enemyCount && playerHealth.streakBreaker == false)
        {
            tenKills.Play();
            enemyCount += 10;
        }
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

    public void KillIncrease()
    {
        switch (enemyCount)
        {
            case 10:
                Debug.Log("PlayAudio1");
                enemyCount += 10;
                break;

            case 20:
                Debug.Log("PlayAudio2");
                enemyCount += 10;
                break;

            case 30:
                Debug.Log("PlayAudio3");
                enemyCount += 10;
                break;

            case 40:
                Debug.Log("PlayAudio4");
                enemyCount += 10;
                break;

            case 50:
                Debug.Log("PlayAudio5");
                enemyCount += 10;
                break;

            case 60:
                Debug.Log("PlayAudio6");
                enemyCount += 10;
                break;

            case 70:
                Debug.Log("PlayAudio7");
                enemyCount += 10;
                break;

            case 80:
                Debug.Log("PlayAudio8");
                enemyCount += 10;
                break;

            case 90:
                Debug.Log("PlayAudio9");
                enemyCount += 10;
                break;

            case 100:
                Debug.Log("PlayAudio10");
                break;
        }
    }
}





