using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    public int playerHealth;
    public ScoreScript points;

    private void Awake()
    {
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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RedEnemy")
        {
            playerHealth -= 1;
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
