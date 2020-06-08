using UnityEngine;

public class WaveController : MonoBehaviour
{
    public static WaveController WController;
    public int eSpeedup = 1;




    void Start()
    {       
        ESpawner.eSpawner.isWaveOver = false;
        WController = this;
    }



   public void WaveComplete()
   {
        ESpawner.eSpawner.isWaveOver = true;
        ESpawner.eSpawner.Wavescreen.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (GameManager.gameManager.saveWave == 1)
        {
            
            if (GameManager.gameManager.score > PlayerPrefs.GetInt("Wave1",0))
            {
                PlayerPrefs.SetInt("Wave1", GameManager.gameManager.score);
                PlayerPrefs.Save();
                Debug.LogError("Overwrite");
            }
        }
        if (GameManager.gameManager.saveWave == 2)
        {
           
            if (GameManager.gameManager.score > PlayerPrefs.GetInt("Wave2", 0))
            {
                PlayerPrefs.SetInt("Wave2", GameManager.gameManager.score);
                PlayerPrefs.Save();
                Debug.LogError("Overwrite");
            }
        }
        if (GameManager.gameManager.saveWave == 3)
        {

            if (GameManager.gameManager.score > PlayerPrefs.GetInt("Wave3", 0))
            {
                PlayerPrefs.SetInt("Wave3", GameManager.gameManager.score);
                PlayerPrefs.Save();
                Debug.LogError("Overwrite");
            }
        }
        if (GameManager.gameManager.saveWave == 4)
        {

            if (GameManager.gameManager.score > PlayerPrefs.GetInt("Wave4", 0))
            {
                PlayerPrefs.SetInt("Wave4", GameManager.gameManager.score);
                PlayerPrefs.Save();
                Debug.LogError("Overwrite");
            }
        }
        if (GameManager.gameManager.saveWave == 5)
        {

            if (GameManager.gameManager.score > PlayerPrefs.GetInt("Wave5", 0))
            {
                PlayerPrefs.SetInt("Wave5", GameManager.gameManager.score);
                PlayerPrefs.Save();
                Debug.LogError("Overwrite");
            }
        }
        if (GameManager.gameManager.saveWave == 6)
        {

            if (GameManager.gameManager.score > PlayerPrefs.GetInt("Wave6", 0))
            {
                PlayerPrefs.SetInt("Wave6", GameManager.gameManager.score);
                PlayerPrefs.Save();
                Debug.LogError("Overwrite");
            }
        }
        if (GameManager.gameManager.saveWave == 7)
        {

            if (GameManager.gameManager.score > PlayerPrefs.GetInt("Wave7", 0))
            {
                PlayerPrefs.SetInt("Wave7", GameManager.gameManager.score);
                PlayerPrefs.Save();
                Debug.LogError("Overwrite");
            }
        }
        if (GameManager.gameManager.saveWave == 8)
        {

            if (GameManager.gameManager.score > PlayerPrefs.GetInt("Wave8", 0))
            {
                PlayerPrefs.SetInt("Wave8", GameManager.gameManager.score);
                PlayerPrefs.Save();
                Debug.LogError("Overwrite");
            }
        }
        if (GameManager.gameManager.saveWave == 9)
        {

            if (GameManager.gameManager.score > PlayerPrefs.GetInt("Wave9", 0))
            {
                PlayerPrefs.SetInt("Wave9", GameManager.gameManager.score);
                PlayerPrefs.Save();
                Debug.LogError("Overwrite");
            }
        }
        if (GameManager.gameManager.saveWave == 10)
        {

            if (GameManager.gameManager.score > PlayerPrefs.GetInt("Wave10", 0))
            {
                PlayerPrefs.SetInt("Wave10", GameManager.gameManager.score);
                PlayerPrefs.Save();
                Debug.LogError("Overwrite");
            }
        }

        GameManager.gameManager.saveWave += 1;
        if (ESpawner.eSpawner.isWaveOver == true)
        {
           ESpawner.eSpawner.waves++;
           ESpawner.eSpawner.isWaveOver = false;
                      
        }
        
   }

    public void NextWave()
    {
        ESpawner.eSpawner.isWaveOver = false;
        ESpawner.eSpawner.Wavescreen.SetActive(false);
        ESpawner.eSpawner.totalToSpawn = 1 * ESpawner.eSpawner.waves ;
        GameManager.gameManager.DifficultySetting();
        ESpawner.eSpawner.streakCount = 0;
        ESpawner.eSpawner.killCount = 0;
        ESpawner.eSpawner.enemyCount = 0;
        ESpawner.eSpawner.enemiesNeeded = ESpawner.eSpawner.totalToSpawn;
        GameManager.gameManager.eSpeed += .5f;
        ESpawner.eSpawner.DoSpawn();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {        
        ESpawner.eSpawner.waveCount.text = ESpawner.eSpawner.waves.ToString();
    }
}
