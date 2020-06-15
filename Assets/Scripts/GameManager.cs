using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
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
    public TextMeshProUGUI waveScore;
    public TextMeshProUGUI waveScore2;
    public TextMeshProUGUI waveScore3;
    public TextMeshProUGUI waveScore4;
    public TextMeshProUGUI waveScore5;
    public TextMeshProUGUI waveScore6;
    public TextMeshProUGUI waveScore7;
    public TextMeshProUGUI waveScore8;
    public TextMeshProUGUI waveScore9;
    public TextMeshProUGUI waveScore10;
    public int saveWave = 1;
    public int gHitCount;
    #endregion

    // private varibles not access by other classes
    #region Private 
    public int score;
    private float misses;
    
    #endregion

    public GameObject[] stars;
    public GameObject resultsBackground;
    
    #region Difficulty adjuster
    public ENemyHealth ehealth;
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
        if (gameManager != null)
        {
            //Debug.LogError(gameManager + " Deleted");
            Destroy(gameManager.gameObject);
        }
        else
        {
            gameManager = this;
            //Debug.LogError(gameManager);
            DontDestroyOnLoad(this);
        }

        if (resultsBackground != null)
        {
            resultsBackground.SetActive(false);
            Debug.Log("resultsBackground works");
        }

       
      
        ehealth = FindObjectOfType<ENemyHealth>();
        if(ehealth == null)
        {
            Debug.Log("ehealth is null");
        }

        if (waveScreen != null)
        {
            waveScreen = Waves.Wavescreen.transform.GetChild(waveNumber).gameObject;
        }

        enemyATK = 1;
        enemyATKCooldown = 4;
        CTime = 20;
        if (SceneManager.sceneCount == 3)
        {
            waveScore.text = PlayerPrefs.GetInt("Wave1", 0).ToString();
            waveScore2.text = PlayerPrefs.GetInt("Wave2", 0).ToString();
            waveScore3.text = PlayerPrefs.GetInt("Wave3", 0).ToString();
            waveScore4.text = PlayerPrefs.GetInt("Wave4", 0).ToString();
            waveScore5.text = PlayerPrefs.GetInt("Wave5", 0).ToString();
            waveScore6.text = PlayerPrefs.GetInt("Wave6", 0).ToString();
            waveScore7.text = PlayerPrefs.GetInt("Wave7", 0).ToString();
            waveScore8.text = PlayerPrefs.GetInt("Wave8", 0).ToString();
            waveScore9.text = PlayerPrefs.GetInt("Wave9", 0).ToString();
            waveScore10.text = PlayerPrefs.GetInt("Wave10", 0).ToString();
        }
        else
        {
            return;
        }

        gHitCount = 0;
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
        if (Input.GetKey(KeyCode.O))
        {
            PlayerPrefs.DeleteAll();
        }
        eHealth = GameObject.FindObjectsOfType<ENemyHealth>();
        if (Waves != null)
        {
            waveName = ESpawner.eSpawner.waves.ToString();
        }
        //CalculateAccuracy();
        if (ScoreManager.scoreManager != null)
        {
            score = ScoreManager.scoreManager.currScore;
        }
        waveScore.text = PlayerPrefs.GetInt("Wave1", 0).ToString();
        waveScore2.text = PlayerPrefs.GetInt("Wave2", 0).ToString();
        waveScore3.text = PlayerPrefs.GetInt("Wave3", 0).ToString();
        waveScore4.text = PlayerPrefs.GetInt("Wave4", 0).ToString();
        waveScore5.text = PlayerPrefs.GetInt("Wave5", 0).ToString();
        waveScore6.text = PlayerPrefs.GetInt("Wave6", 0).ToString();
        waveScore7.text = PlayerPrefs.GetInt("Wave7", 0).ToString();
        waveScore8.text = PlayerPrefs.GetInt("Wave8", 0).ToString();
        waveScore9.text = PlayerPrefs.GetInt("Wave9", 0).ToString();
        waveScore10.text = PlayerPrefs.GetInt("Wave10", 0).ToString();
        if (gHitCount == 3)
        {

            Damage.damage.playerHealth = 0;
        }
    } 

    public void BulletMisses()
    {
        misses++;
    }

    public void CalculateAccuracy()
    {
        accuracy = hits / shotsFired *100;
    }

    public void Starsystem()
    {
            StarCalculation();
    }

    public void StarCalculation()
    {
        CalculateAccuracy();
        if (accuracy >= 79 && score >= 38161 && greenDeaths >= 35)
        {
            resultsBackground.SetActive(true);
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            stars[3].SetActive(true);
            stars[4].SetActive(true);
            Debug.LogError("5 star rating");

        }
        else if (accuracy >= 59 && score >= 28621 && greenDeaths >= 28)
        {
            resultsBackground.SetActive(true);
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            stars[3].SetActive(true);
            stars[4].SetActive(false);

            Debug.LogError("4 star rating");

        }
        else if (accuracy >= 35 && score >= 19081 && greenDeaths >= 21)
        {
            resultsBackground.SetActive(true);
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            stars[3].SetActive(false);
            stars[4].SetActive(false);
            Debug.LogError("3 star rating");

        }
        else if (accuracy >= 15 && score >= 9541 && greenDeaths >= 14)
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
                pD1 = 11;
                pD2 = 10;
                pDA2 = 16;
                pD3 = 15;
                pDA3 = 20;
                pD4 = 19;
                spawnTime = 0.5f;
                repeatTime = 1.5f;
                break;
            case "2":
                pD1 = 11;
                pD2 = 10;
                pDA2 = 16;
                pD3 = 15;
                pDA3 = 20;
                pD4 = 19;
                spawnTime = 0.5f;
                repeatTime = 1.5f;
                enemyATK = 1;
                enemyATKCooldown = 2;
                break;
            case "3":
                pD1 = 11;
                pD2 = 10;
                pDA2 = 16;
                pD3 = 15;
                pDA3 = 20;
                pD4 = 19;
                spawnTime = 0.5f;
                repeatTime = 1.5f;
                CTime = 14;
               
                break;
            case "4":
                pD1 = 11;
                pD2 = 10;
                pDA2 = 16;
                pD3 = 15;
                pDA3 = 20;
                pD4 = 19;
                spawnTime = 0.5f;
                repeatTime = 1.5f;
                CTime = 13;
                break;
            case "5":
                pD1 = 11;
                pD2 = 10;
                pDA2 = 16;
                pD3 = 15;
                pDA3 = 20;
                pD4 = 19;
                spawnTime = 0.5f;
                repeatTime = 1.5f;
                CTime = 12;
                break;
            case "6":
                pD1 = 11;
                pD2 = 10;
                pDA2 = 16;
                pD3 = 15;
                pDA3 = 20;
                pD4 = 19;
                spawnTime = 0.5f;
                repeatTime = 1.5f;
                CTime = 10;
                enemyATK = 2;
                enemyATKCooldown = 2;
                break;
            case "7":
                pD1 = 11;
                pD2 = 10;
                pDA2 = 16;
                pD3 = 15;
                pDA3 = 20;
                pD4 = 19;
                spawnTime = 0.5f;
                repeatTime = 1.5f;
                CTime = 9;
                break;
            case "8":
                pD1 = 11;
                pD2 = 10;
                pDA2 = 16;
                pD3 = 15;
                pDA3 = 20;
                pD4 = 19;
                spawnTime = 0.5f;
                repeatTime = 1.5f;
                CTime = 8;
                break;
            case "9":
                pD1 = 6;
                pD2 = 10;
                pDA2 = 16;
                pD3 = 21;
                pDA3 = 26;
                pD4 = 31;
                spawnTime = 0.5f;
                repeatTime = 1.5f;
                CTime = 6;
                enemyATK = 2.5f;
                enemyATKCooldown = 1;
                break;
            
        }
    }
}
    

       


