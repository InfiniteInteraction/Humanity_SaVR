using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HighScoreRead : MonoBehaviour
{
    public TextMeshProUGUI highScoreRead = null;
    public TextMeshProUGUI highScoreRead2 = null;
    public TextMeshProUGUI highScoreRead3 = null;
    public TextMeshProUGUI highScoreRead4 = null;
    public TextMeshProUGUI highScoreRead5 = null;
    public TextMeshProUGUI highScoreRead6 = null;
    public TextMeshProUGUI highScoreRead7 = null;
    public TextMeshProUGUI highScoreRead8 = null;
    public TextMeshProUGUI highScoreRead9 = null;
    public TextMeshProUGUI highScoreRead10 = null;
  
    public ScoreManager sM;

    private void Start()
    {
        highScoreRead.text = "HighScore: " + sM._highScores[2].ToString();
        highScoreRead2.text = "HighScore: " + sM._highScores[3].ToString();
        highScoreRead3.text = "HighScore: " + sM._highScores[4].ToString();
        highScoreRead4.text = "HighScore: " + sM._highScores[5].ToString();
        highScoreRead5.text = "HighScore: " + sM._highScores[6].ToString();
        highScoreRead6.text = "HighScore: " + sM._highScores[7].ToString();
        highScoreRead7.text = "HighScore: " + sM._highScores[8].ToString();
        highScoreRead8.text = "HighScore: " + sM._highScores[9].ToString();
        highScoreRead9.text = "HighScore: " + sM._highScores[10].ToString();
        highScoreRead10.text = "HighScore: " + sM._highScores[11].ToString();
    }
    private void Update()
    {
        highScoreRead.text = "HighScore: " + sM._highScores[2].ToString();
        highScoreRead2.text = "HighScore: " + sM._highScores[3].ToString();
        highScoreRead3.text = "HighScore: " + sM._highScores[4].ToString();
        highScoreRead4.text = "HighScore: " + sM._highScores[5].ToString();
        highScoreRead5.text = "HighScore: " + sM._highScores[6].ToString();
        highScoreRead6.text = "HighScore: " + sM._highScores[7].ToString();
        highScoreRead7.text = "HighScore: " + sM._highScores[8].ToString();
        highScoreRead8.text = "HighScore: " + sM._highScores[9].ToString();
        highScoreRead9.text = "HighScore: " + sM._highScores[10].ToString();
        highScoreRead10.text = "HighScore: " + sM._highScores[11].ToString();
    }
}
