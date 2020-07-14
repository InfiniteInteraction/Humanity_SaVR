using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPush : MonoBehaviour
{
    public StartMenuFunctionality sMU;

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
            SceneManager.LoadScene("OVRMenu");           
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("NextWave"))
        {
            WaveController.WController.NextWave();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("How"))
        {
            SceneManager.LoadScene("HowToPlay_New");
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("PressAnyButton"))
        {
            SceneManager.LoadScene("OVRMenu");
        }

    }
}
