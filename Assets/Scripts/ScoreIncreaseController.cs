using UnityEngine;

public class ScoreIncreaseController : MonoBehaviour
{
    private static ScoreIncreaseDisplay scoreIncreaseFloater;
    private static GameObject scorePoint;

    public static void Initialize()
    {
        scorePoint = GameObject.Find("ScoreIncreasePoint");
        if (!scoreIncreaseFloater)
        {
            scoreIncreaseFloater = Resources.Load<ScoreIncreaseDisplay>("ScoreIncrease");
        }
    }

    public static void CreateScoreFloater(string scoreText)
    {
        ScoreIncreaseDisplay instance = Instantiate(scoreIncreaseFloater);
        instance.transform.SetParent(scorePoint.transform, false);
        instance.ScoreIncreaseValue(scoreText);
    }
}
