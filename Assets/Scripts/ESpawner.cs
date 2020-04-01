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
            KillIncrease();
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
                FindObjectOfType<Audiomanager>().Play("Ridiculousness");
                enemyCount += 10;
                break;

            case 20:
                FindObjectOfType<Audiomanager>().Play("Thats20");
                enemyCount += 10;
                break;

            case 30:
                FindObjectOfType<Audiomanager>().Play("Spectacular");
                enemyCount += 10;
                break;

            case 40:
                FindObjectOfType<Audiomanager>().Play("KillGrind");
                enemyCount += 10;
                break;

            case 50:
                FindObjectOfType<Audiomanager>().Play("BulletStorm");
                enemyCount += 10;
                break;

            case 60:
                FindObjectOfType<Audiomanager>().Play("Overachiever");
                enemyCount += 10;
                break;

            case 70:
                FindObjectOfType<Audiomanager>().Play("HahshfalahThis");
                enemyCount += 10;
                break;

            case 80:
                FindObjectOfType<Audiomanager>().Play("MoreBulletsLessProblems");
                enemyCount += 10;
                break;

            case 90:
                FindObjectOfType<Audiomanager>().Play("LethalProtector");
                enemyCount += 10;
                break;

            case 100:
                FindObjectOfType<Audiomanager>().Play("InvincibleKillingMachine");
                break;
        }
    }
}





