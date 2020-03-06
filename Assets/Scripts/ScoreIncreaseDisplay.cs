using UnityEngine;
using UnityEngine.UI;

public class ScoreIncreaseDisplay : MonoBehaviour
{
    public Animator scoreIncreaseAnim = null;
    private Text scoreIncreaseText;

    private void OnEnable()
    {
        if(scoreIncreaseAnim == null)
        {
            scoreIncreaseAnim = GetComponentInChildren<Animator>();
            AnimatorClipInfo[] clipInfo = scoreIncreaseAnim.GetCurrentAnimatorClipInfo(0);
            Destroy(gameObject, clipInfo[0].clip.length);
            scoreIncreaseText = scoreIncreaseAnim.GetComponent<Text>();
        }
        else
        {
            AnimatorClipInfo[] clipInfo = scoreIncreaseAnim.GetCurrentAnimatorClipInfo(0);
            Destroy(gameObject, clipInfo[0].clip.length);
            scoreIncreaseText = scoreIncreaseAnim.GetComponent<Text>();
        }
    }

    public void ScoreIncreaseValue(string increaseValue)
    {
        scoreIncreaseText.text = increaseValue;
    }
}
