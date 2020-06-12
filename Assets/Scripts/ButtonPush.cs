﻿using System.Collections;
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
