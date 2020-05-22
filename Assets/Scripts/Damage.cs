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
            SceneManager.LoadScene(0);
        }
    }
}
