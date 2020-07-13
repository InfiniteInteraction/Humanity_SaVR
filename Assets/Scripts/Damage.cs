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
    }

   public void PlayerDeath()
    {
        if (playerHealth == 0)
        {
            Audiomanager.audiomanager.Play("WaveFailed");
        }
    }
}
