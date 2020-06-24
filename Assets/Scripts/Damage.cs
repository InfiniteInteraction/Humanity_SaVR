using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    public static Damage damage; 
    public float playerHealth;
    public ScoreScript points;

    private void Awake()
    {
        damage = this;
        playerHealth = 100;
    }
    public void Update()
    {
        Mathf.Clamp(playerHealth, 0, 100);
        if (Input.GetKeyDown(KeyCode.L))
        {           
            Debug.Log("points");            
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SceneManager.LoadScene(1);
        }        
    }

   public void PlayerDeath()
    {
        if (playerHealth <= 0)
        {
            Audiomanager.audiomanager.Play("WaveFailed");
            Debug.Log("Player Dead");
            //SceneManager.LoadScene(0);
        }
    }
}
