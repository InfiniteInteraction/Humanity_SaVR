using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ESpawner : MonoBehaviour
{
    public static ESpawner eSpawner;

    public Text waveCount;
    public int waves = 0;

    public GameObject[] spawners;
    public bool isWaveOver;
    public Health playerHealth;

    //Spawners area 
    public int totalToSpawn = 15;
    public GameObject enemyPrefab;
    public GameObject enemyGreenPrefab;

    public int streakCount;
    public int killCount;
    public int killCountMax = 20;

    public GameObject Wavescreen;
    public int enemyCount;
    public int enemiesKilled = 0;
    public int enemiesNeeded;


    //Spawners Area

    public float enemySpeed = 3.5f;

    void Awake()
    {
        eSpawner = this;  
    }
    void Start()
    {
        GameManager.gameManager.DifficultySetting();       
        enemySpeed = GameManager.gameManager.eSpeed;    
        Wavescreen.SetActive(false);
        waveCount.text = waves.ToString();
        enemiesNeeded = totalToSpawn;
        DoSpawn();
    }


    //Spawners Area Begin
    //public void Spawn(int _totalToSpawn)
    //{
    //    totalToSpawn = _totalToSpawn;
    //}

    public void DoSpawn()
    {
        GameObject enemy = Instantiate(enemyPrefab, spawners[Random.Range(0, spawners.Length)].transform.position, Quaternion.identity);
        totalToSpawn--;
        //enemy.GetComponent<NavMeshAgent>().speed = enemySpeed;
        Invoke("DoSpawn", 1);
    }

    //public void SpawnCount()
    //{
    //    if (enemyCount == enemiesNeeded)
    //    {
    //        //waves++;
    //        //Wavescreen.SetActive(true);
    //        //GameManager.gameManager.levelOver = true;
    //        //Invoke("GetStarCalc", 0);
    //    }
    //}

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

    public void RepeatSpawning()
    {
        if(totalToSpawn <= 0)
        {
            CancelInvoke("DoSpawn");
            if (enemyCount == enemiesNeeded)
            {
                WaveController.WController.WaveComplete();
                enemyCount += 1;
            }
        }
    }

    private void Update()
    {
        RepeatSpawning();
    }
}





