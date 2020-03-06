using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    Scene scene;
    public static NextLevel nLScript;
    public static bool gamePaused = false;
    public GameObject pausemenuUI;

    private void Awake()
    {
        nLScript = this;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();            
            }
        }
    }
       public void Resume()
      {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
      }
       public void Pause()
       {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
       }
   
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
    public void Quit()
    {
        ScoreManager.scoreManager.Save();
        Time.timeScale = 1f;
        gamePaused = false;
        SceneManager.LoadScene(0);
    }
}
