using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public ScoreManager scoreManager;   
    TextMeshProUGUI score;
    public void Awake()
    {
        score = GetComponent<TextMeshProUGUI>();       
    }
    public void Update()
    {
        score.text = "Score: " + scoreManager.currScore ;      
    }
    public void Multi(int points)
    {
        scoreManager.currScore += points;     
    }
}