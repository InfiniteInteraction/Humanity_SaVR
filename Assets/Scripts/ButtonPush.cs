using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPush : MonoBehaviour
{
    public StartMenuFunctionality sMU;
    public GameObject panel;

    void Start()
    {
        panel = null;
    }

    void OnTriggerEnter(Collider other)
    {
        
        if((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag ==("PlayButton"))
        {
            sMU.NewGame();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag ==("CreditsButton"))
        {
            sMU.Credits();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("QuitButton"))
        {
            sMU.ExitGame();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("LevelOne"))
        {
            sMU.LevelOne();
            ScoreManager.scoreManager.Save();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("LevelTwo"))
        {
            sMU.LevelTwo();
            ScoreManager.scoreManager.Save();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("LevelThree"))
        {
            sMU.LevelThree();
            ScoreManager.scoreManager.Save();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("LevelFour"))
        {
            sMU.LevelFour();
            ScoreManager.scoreManager.Save();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("LevelFive"))
        {
            sMU.LevelFive();
            ScoreManager.scoreManager.Save();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("LevelSix"))
        {
            sMU.LevelSix();
            ScoreManager.scoreManager.Save();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("LevelSeven"))
        {
            sMU.LevelSeven();
            ScoreManager.scoreManager.Save();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("LevelEight"))
        {
            sMU.LevelEight();
            ScoreManager.scoreManager.Save();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("LevelNine"))
        {
            sMU.LevelNine();
            ScoreManager.scoreManager.Save();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("LevelTen"))
        {
            sMU.LevelTen();
            ScoreManager.scoreManager.Save();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("PauseQuitButton"))
        {
            ScoreManager.scoreManager.Save();
            SceneManager.LoadScene(0);
            
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("NextWave"))
        {
            WaveController.WController.NextWave();
        }


    }
}
