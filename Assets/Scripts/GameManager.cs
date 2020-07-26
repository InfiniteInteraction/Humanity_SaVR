using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    // public varibles for access by other classes
    #region Public 
    //public bool levelOver = true;    
    public int greenDeaths;
    public float accuracy;
    public float shotsFired;
    public float hits;
    public ESpawner Waves;
    public GameObject waveScreen;
    public string waveName;
    public float enemyATK;
    public float enemyATKTime;
    public float enemyATKCooldown;
    public ENemyHealth[] eHealth;
    public int waveNumber = 1;
    public int CTime;
    public float eSpeed = 3.5f;
    public int saveWave = 1;
    
    [Header("Refill Ammo")]
    public List<bool> GunAmmo = new List<bool>
    {
       false,
       false,
       false
    };
    #endregion

    // private varibles not access by other classes
    #region Private 
    public int score;
    private float misses;

    #endregion

    public GameObject[] stars;
    public GameObject resultsBackground;

    #region Difficulty adjuster
    public int pD1;
    public int pD2;
    public int pDA2;
    public int pD3;
    public int pDA3;
    public int pD4;

    public float spawnTime;
    public float repeatTime;
    #endregion
    private void Awake()
    {
        //gameManager = this;
        //levelOver = false;
        if (gameManager == null)
        {
            //Debug.LogError(gameManager + " Deleted");
            gameManager = this;
            //Debug.LogError(gameManager);
            DontDestroyOnLoad(gameManager.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        enemyATK = 1;
        enemyATKCooldown = 4;
        CTime = 12;
        //gHitCount = 0;

    }
    public void PlayButtonReturn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("OVRMenu");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene("Test Credits");
        }
        Checks();
        if (SceneManager.sceneCount == 1)
        {
            WaveHolder WScore = FindObjectOfType<WaveHolder>();
            if (WScore != null)
            {
                foreach (GameObject ScoreText in WScore.WaveScoreText)
                {
                    string WaveName = ScoreText.name.ToString();
                }
            }
        }
        else
        {
            return;
        }

        if (Input.GetKey(KeyCode.O))
        {
            PlayerPrefs.DeleteAll();
        }
        eHealth = GameObject.FindObjectsOfType<ENemyHealth>();
        if (Waves != null)
        {
            waveName = ESpawner.eSpawner.waves.ToString();
        }
        if (ScoreManager.scoreManager != null)
        {
            score = ScoreManager.scoreManager.currScore;
        }

        if (HighScore_Table.highScore_Table != null)
        {
            HighScore_Table.highScore_Table.pScore = score;

        }
        
        if (Waves != null)
        {
            DifficultySetting();
        }
        if (Damage.damage.playerHealth <= 1)
        {
            PlayerPrefs.SetInt("PlayerScore", HighScore_Table.highScore_Table.pScore);
            PlayerPrefs.Save();
        }
    }

    public void BulletMisses()
    {
        misses++;
    }

    public void CalculateAccuracy()
    {
        accuracy = hits / shotsFired * 100;
    }

    public void Starsystem()
    {
        StarCalculation();
        HighScore_Table.highScore_Table.AddHighscoreEntry(score, "SaVR");
    }

    public void StarCalculation()
    {
        CalculateAccuracy();
        if (accuracy >= 60 && score >= 38161 && greenDeaths >= 35)
        {
            resultsBackground.SetActive(true);
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            stars[3].SetActive(true);
            stars[4].SetActive(true);
            Debug.LogError("5 star rating");

        }
        else if (accuracy >= 40 && score >= 28621 && greenDeaths >= 28)
        {
            resultsBackground.SetActive(true);
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            stars[3].SetActive(true);
            stars[4].SetActive(false);

            Debug.LogError("4 star rating");

        }
        else if (accuracy >= 25 && score >= 19081 && greenDeaths >= 21)
        {
            resultsBackground.SetActive(true);
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            stars[3].SetActive(false);
            stars[4].SetActive(false);
            Debug.LogError("3 star rating");

        }
        else if (accuracy >= 10 && score >= 9541 && greenDeaths >= 14)
        {
            resultsBackground.SetActive(true);
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(false);
            stars[3].SetActive(false);
            stars[4].SetActive(false);
            Debug.LogError("2 star rating");
        }
        else
        {
            resultsBackground.SetActive(true);
            stars[0].SetActive(true);
            stars[1].SetActive(false);
            stars[2].SetActive(false);
            stars[3].SetActive(false);
            stars[4].SetActive(false);


            Debug.LogError("1 star rating");
        }
    }

    public void DifficultySetting()
    {
        waveName = ESpawner.eSpawner.waves.ToString();
        switch (waveName)
        {
            case "0":
                pD1 = 11;
                pD2 = 10;
                pDA2 = 16;
                pD3 = 15;
                pDA3 = 20;
                pD4 = 19;
                spawnTime = 0.5f;
                repeatTime = 1.5f;
                break;
            case "1":
                pD1 = 10;
                pD2 = 9;
                pDA2 = 13;
                pD3 = 12;
                pDA3 = 20;
                pD4 = 19;
                spawnTime = 0.5f;
                repeatTime = 1.5f;
                enemyATK = 2;
                CTime = 10;
                break;
            case "2":
                pD1 = 8;
                pD2 = 7;
                pDA2 = 10;
                pD3 = 9;
                pDA3 = 15;
                pD4 = 14;
                spawnTime = 0.5f;
                repeatTime = 1.5f;
                enemyATK = 2;
                enemyATKCooldown = 2;
                CTime = 8;
                break;
            case "3":
                pD1 = 8;
                pD2 = 7;
                pDA2 = 10;
                pD3 = 9;
                pDA3 = 15;
                pD4 = 14;
                spawnTime = 0.5f;
                repeatTime = 1.5f;
                enemyATK = 2;
                CTime = 6;
                break;
            case "4":
                pD1 = 8;
                pD2 = 7;
                pDA2 = 10;
                pD3 = 9;
                pDA3 = 15;
                pD4 = 14;
                spawnTime = 0.5f;
                repeatTime = 1.5f;
                CTime = 5;
                break;
            case "5":
                pD1 = 8;
                pD2 = 7;
                pDA2 = 10;
                pD3 = 9;
                pDA3 = 15;
                pD4 = 14;
                spawnTime = 0.5f;
                repeatTime = 1.5f;
                break;
            case "6":
                pD1 = 8;
                pD2 = 7;
                pDA2 = 10;
                pD3 = 9;
                pDA3 = 15;
                pD4 = 14;
                spawnTime = 0.5f;
                repeatTime = 1.5f;
                enemyATK = 2;
                enemyATKCooldown = 2;
                break;
            case "7":
                pD1 = 8;
                pD2 = 7;
                pDA2 = 10;
                pD3 = 9;
                pDA3 = 15;
                pD4 = 14;
                spawnTime = 0.5f;
                repeatTime = 1.5f;
                enemyATK = 2;
                break;
            case "8":
                pD1 = 6;
                pD2 = 5;
                pDA2 = 8;
                pD3 = 7;
                pDA3 = 11;
                pD4 = 10;
                spawnTime = 0.5f;
                repeatTime = 1.5f;
                CTime = 4;
                break;
            case "9":
                pD1 = 6;
                pD2 = 5;
                pDA2 = 8;
                pD3 = 7;
                pDA3 = 11;
                pD4 = 10;
                spawnTime = 0.5f;
                repeatTime = 1.5f;
                CTime = 3;
                enemyATK = 2;
                enemyATKCooldown = 1.5f;
                break;

        }
    }
    public void Checks()
    {
        Waves = FindObjectOfType<ESpawner>();
        if (Waves != null)
        {
            waveScreen = Waves.Wavescreen.transform.GetChild(waveNumber).gameObject;
        }
    }

    public void AmmoGain()
    {
        for (int i = 0; i < GunAmmo.Count; i++)
        {
            GunAmmo[i] = true;
            Debug.Log(GunAmmo[i]);
        }       
    }
    public void AmmoReset()
    {
        for (int i = 0; i < GunAmmo.Count; i++)
        {
            GunAmmo[i] = false;
            Debug.Log(GunAmmo[i]);
        }
    }
    public void RECHARGE()
    {
        int RechTemp = GetComponent<WeaponSwitch>().WeaponPlace;
        if (GunAmmo[RechTemp] == true)
        {
            GunTestVR Gunny = FindObjectOfType<GunTestVR>();
            Gunny.RegainAmmo();
            GunAmmo[RechTemp] = false;
        }
    }
}