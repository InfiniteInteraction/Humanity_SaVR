using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HighScoreRead : MonoBehaviour
{
    public TextMeshProUGUI highScoreRead = null;
   
  
   

    private void Start()
    {
        highScoreRead.text = PlayerPrefs.GetInt("PlayerScore").ToString();
       
    }
    private void Update()
    {
        highScoreRead.text = PlayerPrefs.GetInt("PlayerScore").ToString();

    }
}
