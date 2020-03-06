using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour
{
    Text displayText;
    public int sceneIndexValue = 0;

    private void Start()
    {
        displayText = GetComponent<Text>();
        GetHighScoreValue();
    }

    void GetHighScoreValue()
    {
        //displayText.text = ScoreManager.scoreManager.GetHighScore(sceneIndexValue).ToString();
    }
}
