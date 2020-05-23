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
        ESpawner.eSpawner.totalToSpawn = 20 * ESpawner.eSpawner.waves ;
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
