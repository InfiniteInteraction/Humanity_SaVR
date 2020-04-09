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


    //Spawners Area Begin
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

    public void KillStreak()
    {
        switch (streakCount)
        {
            case 10:
                Audiomanager.audiomanager.Play("Ridiculousness");
                break;

            case 20:
                Audiomanager.audiomanager.Play("Thats20");
                break;

            case 30:
                Audiomanager.audiomanager.Play("Spectacular");
                break;

            case 40:
                Audiomanager.audiomanager.Play("KillGrind");
                break;

            case 50:
                Audiomanager.audiomanager.Play("BulletStorm"); 
                break;

            case 60:
                Audiomanager.audiomanager.Play("Overachiever");
                break;

            case 70:
                Audiomanager.audiomanager.Play("HahshfalahThis");
                break;

            case 80:
                Audiomanager.audiomanager.Play("MoreBulletsLessProblems");
                break;

            case 90:
                Audiomanager.audiomanager.Play("LethalProtector");
                break;

            case 100:
                Audiomanager.audiomanager.Play("InvincibleKillingMachine");
                break;
        }
    }
}





