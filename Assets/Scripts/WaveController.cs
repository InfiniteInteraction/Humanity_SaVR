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
        Audiomanager.audiomanager.Play("WaveComplete");
        ESpawner.eSpawner.Wavescreen.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (GameManager.gameManager.saveWave == 1)
        {
            
            if (GameManager.gameManager.score > PlayerPrefs.GetInt("Wave 1 Score",0))
            {
                PlayerPrefs.SetInt("Wave 1 Score", GameManager.gameManager.score);
                PlayerPrefs.Save();
               
            }
        }
        if (GameManager.gameManager.saveWave == 2)
        {
           
            if (GameManager.gameManager.score > PlayerPrefs.GetInt("Wave 2 Score", 0))
            {
                PlayerPrefs.SetInt("Wave 2 Score", GameManager.gameManager.score);
                PlayerPrefs.Save();
                
            }
        }
        if (GameManager.gameManager.saveWave == 3)
        {

            if (GameManager.gameManager.score > PlayerPrefs.GetInt("Wave 3 Score", 0))
            {
                PlayerPrefs.SetInt("Wave 3 Score", GameManager.gameManager.score);
                PlayerPrefs.Save();
               
            }
        }
        if (GameManager.gameManager.saveWave == 4)
        {

            if (GameManager.gameManager.score > PlayerPrefs.GetInt("Wave 4 Score", 0))
            {
                PlayerPrefs.SetInt("Wave 4 Score", GameManager.gameManager.score);
                PlayerPrefs.Save();
               
            }
        }
        if (GameManager.gameManager.saveWave == 5)
        {

            if (GameManager.gameManager.score > PlayerPrefs.GetInt("Wave 5 Score", 0))
            {
                PlayerPrefs.SetInt("Wave 5 Score", GameManager.gameManager.score);
                PlayerPrefs.Save();
               
            }
        }
        if (GameManager.gameManager.saveWave == 6)
        {

            if (GameManager.gameManager.score > PlayerPrefs.GetInt("Wave 6 Score", 0))
            {
                PlayerPrefs.SetInt("Wave 6 Score", GameManager.gameManager.score);
                PlayerPrefs.Save();
               
            }
        }
        if (GameManager.gameManager.saveWave == 7)
        {

            if (GameManager.gameManager.score > PlayerPrefs.GetInt("Wave 7 Score", 0))
            {
                PlayerPrefs.SetInt("Wave 7 Score", GameManager.gameManager.score);
                PlayerPrefs.Save();
               
            }
        }
        if (GameManager.gameManager.saveWave == 8)
        {

            if (GameManager.gameManager.score > PlayerPrefs.GetInt("Wave 8 Score", 0))
            {
                PlayerPrefs.SetInt("Wave 8 Score", GameManager.gameManager.score);
                PlayerPrefs.Save();
              
            }
        }
        if (GameManager.gameManager.saveWave == 9)
        {

            if (GameManager.gameManager.score > PlayerPrefs.GetInt("Wave 9 Score", 0))
            {
                PlayerPrefs.SetInt("Wave 9 Score", GameManager.gameManager.score);
                PlayerPrefs.Save();
               
            }
        }
        if (GameManager.gameManager.saveWave == 10)
        {

            if (GameManager.gameManager.score > PlayerPrefs.GetInt("Wave 10 Score", 0))
            {
                PlayerPrefs.SetInt("Wave 10 Score", GameManager.gameManager.score);
                PlayerPrefs.Save();
                
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
