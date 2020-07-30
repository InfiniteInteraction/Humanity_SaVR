using UnityEngine;

public class WaveController : MonoBehaviour
{
    public static WaveController WController;

    void Start()
    {       
        WController = this;
        if (ESpawner.eSpawner == null)
        {
            return;
        }
        ESpawner.eSpawner.isWaveOver = false;
    }

   public void WaveComplete()
   {
        ESpawner.eSpawner.isWaveOver = true;

        ESpawner.eSpawner.Wavescreen.SetActive(true);   

        GameManager.gameManager.saveWave += 1;
        if (ESpawner.eSpawner.isWaveOver == true)
        {
            ESpawner.eSpawner.waves++;
            ESpawner.eSpawner.isWaveOver = false;

        }
        if (ESpawner.eSpawner.waves <= 9)
        {
            Audiomanager.audiomanager.Play("WaveComplete");
        }
        PlayerPrefs.SetInt("PlayerScore", HighScore_Table.highScore_Table.pScore);
        PlayerPrefs.Save();
       
    }

    public void NextWave()
    {
        ESpawner.eSpawner.isWaveOver = false;
        ESpawner.eSpawner.Wavescreen.SetActive(false);
        ESpawner.eSpawner.totalToSpawn = 4 * ESpawner.eSpawner.waves ;
        GameManager.gameManager.DifficultySetting();
        ESpawner.eSpawner.streakCount = 0;
        ESpawner.eSpawner.killCount = 0;
        ESpawner.eSpawner.enemyCount = 0;
        ESpawner.eSpawner.enemiesNeeded = ESpawner.eSpawner.totalToSpawn;
        GameManager.gameManager.eSpeed += .5f;
        ESpawner.eSpawner.DoSpawn();
    }

    public void Update()
    {
        if (ESpawner.eSpawner == null)
        {
            return;
        }
        else 
        {
            ESpawner.eSpawner.waveCount.text = ESpawner.eSpawner.waves.ToString(); 
        }
    }
}
