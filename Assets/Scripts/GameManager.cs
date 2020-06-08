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
        waveScore.text = "Wave 1 Highscore " + PlayerPrefs.GetInt("Wave1", 0).ToString();
        waveScore2.text = "Wave 2 Highscore " + PlayerPrefs.GetInt("Wave2", 0).ToString();
        waveScore3.text = "Wave 3 Highscore " + PlayerPrefs.GetInt("Wave3", 0).ToString();
        waveScore4.text = "Wave 4 Highscore " + PlayerPrefs.GetInt("Wave4", 0).ToString();
        waveScore5.text = "Wave 5 Highscore " + PlayerPrefs.GetInt("Wave5", 0).ToString();
        waveScore6.text = "Wave 6 Highscore " + PlayerPrefs.GetInt("Wave6", 0).ToString();
        waveScore7.text = "Wave 7 Highscore " + PlayerPrefs.GetInt("Wave7", 0).ToString();
        waveScore8.text = "Wave 8 Highscore " + PlayerPrefs.GetInt("Wave8", 0).ToString();
        waveScore9.text = "Wave 9 Highscore " + PlayerPrefs.GetInt("Wave9", 0).ToString();
        waveScore10.text = "Wave 10 Highscore " + PlayerPrefs.GetInt("Wave10", 0).ToString();

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
        waveScore.text = "Wave 1 Highscore " + PlayerPrefs.GetInt("Wave1", 0).ToString();
        waveScore2.text = "Wave 2 Highscore " + PlayerPrefs.GetInt("Wave2", 0).ToString();
        waveScore3.text = "Wave 3 Highscore " + PlayerPrefs.GetInt("Wave3", 0).ToString();
        waveScore4.text = "Wave 4 Highscore " + PlayerPrefs.GetInt("Wave4", 0).ToString();
        waveScore5.text = "Wave 5 Highscore " + PlayerPrefs.GetInt("Wave5", 0).ToString();
        waveScore6.text = "Wave 6 Highscore " + PlayerPrefs.GetInt("Wave6", 0).ToString();
        waveScore7.text = "Wave 7 Highscore " + PlayerPrefs.GetInt("Wave7", 0).ToString();
        waveScore8.text = "Wave 8 Highscore " + PlayerPrefs.GetInt("Wave8", 0).ToString();
        waveScore9.text = "Wave 9 Highscore " + PlayerPrefs.GetInt("Wave9", 0).ToString();
        waveScore10.text = "Wave 10 Highscore " + PlayerPrefs.GetInt("Wave10", 0).ToString();
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
        if (accuracy >= 79 && score >= 126500 && greenDeaths >= 122)
        {
            resultsBackground.SetActive(true);
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            stars[3].SetActive(true);
            stars[4].SetActive(true);
            Debug.Log("5 star rating");

        }
        else if (accuracy >= 59 && score >= 101200 && greenDeaths >= 98)
        {
            resultsBackground.SetActive(true);
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            stars[3].SetActive(true);
            Debug.Log("4 star rating");

        }
        else if (accuracy >= 39 && score >= 75900 && greenDeaths >= 73)
        {
            resultsBackground.SetActive(true);
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            Debug.Log("3 star rating");

        }
        else if (accuracy >= 19 && score >= 50600 && greenDeaths >= 49)
        {
            resultsBackground.SetActive(true);
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            Debug.Log("2 star rating");
        }
        else
        {
            resultsBackground.SetActive(true);
            stars[0].SetActive(true);
            Debug.Log("1 star rating");
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
                CTime = 16;
                enemyATK = 1;
                enemyATKCooldown = 5;
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
                CTime = 12;
                enemyATK = 2;
                enemyATKCooldown = 3;
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
                enemyATK = 3;
                enemyATKCooldown = 1;
                break;
            
        }
    }
}
    

       


