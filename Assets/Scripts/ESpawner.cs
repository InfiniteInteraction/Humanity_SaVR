using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class ESpawner : MonoBehaviour
{
    public static ESpawner eSpawner;

    public TextMeshProUGUI waveCount;
    public int waves = 0;

    public GameObject[] spawners;
    public bool isWaveOver;
    public GameObject[] stars;


    //Spawners area 
    public int totalToSpawn = 15;
    public GameObject enemyPrefab;
    public GameObject enemyGreenPrefab;

    public int streakCount;
    public int killCount;
    public int killCountMax = 20;

    public GameObject Wavescreen;
    public GameObject Results;
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
        GameManager.gameManager.resultsBackground = Results;
        Results.SetActive(false);
        GameManager.gameManager.stars = stars;
        waveCount.text = waves.ToString();
        enemiesNeeded = totalToSpawn;
        DoSpawn();
    }

    public void DoSpawn()
    {
        GameObject enemy = Instantiate(enemyPrefab, spawners[Random.Range(0, spawners.Length)].transform.position, Quaternion.identity);
        totalToSpawn--;
        //enemy.GetComponent<NavMeshAgent>().speed = enemySpeed;
        Invoke("DoSpawn", 1);
    }

    public void SpawnGreen()
    {
        if (killCount == killCountMax)
        {
            Instantiate(enemyGreenPrefab, spawners[Random.Range(0, spawners.Length)].transform.position, Quaternion.identity);
            killCount = 0;
        }
    }
    void wave10Complete()
    {
        
        Wavescreen.SetActive(false);
        Results.SetActive(true);
        Audiomanager.audiomanager.Play("LevelComplete");
        GameManager.gameManager.Starsystem();
    }

    public void KillStreak()
    {
        switch (streakCount)
        {
            case 7:
                Audiomanager.audiomanager.Play("Work it");
                break;

            case 14:
                Audiomanager.audiomanager.Play("Sick");
                break;

            case 21:
                Audiomanager.audiomanager.Play("SaVR Spree");
                break;

            case 28:
                Audiomanager.audiomanager.Play("Savior Spree");
                break;

            case 35:
                Audiomanager.audiomanager.Play("Savage SaVR Spree"); 
                break;

            case 42:
                Audiomanager.audiomanager.Play("Savage Savior Spree");
                break;

            case 49:
                Audiomanager.audiomanager.Play("Maximum Execution");
                break;

            case 56:
                Audiomanager.audiomanager.Play("Emaculate Execution");
                break;

            case 63:
                Audiomanager.audiomanager.Play("Difinitive Domination");
                break;

            //case 100:
            //    Audiomanager.audiomanager.Play("InvincibleKillingMachine");
            //    break;
        }
    }

    public void RepeatSpawning()
    {
        if(totalToSpawn <= 0)
        {
            CancelInvoke("DoSpawn");
            if (enemyCount == enemiesNeeded && GameManager.gameManager.eHealth.Length == 0)
            {
                WaveController.WController.WaveComplete();
                enemyCount += 1;
                
                if (waves == 10)
                {
                   
                    
                    wave10Complete();
                }
            }
        }
    }

    private void Update()
    {
        RepeatSpawning();
    }
}





