using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathFade : MonoBehaviour
{
    public Image faceOut;
    public float fadeTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Damage.damage.playerHealth <= 0)
        {
            StartCoroutine(fadeImage());
        }
    }

    IEnumerator fadeImage()
    {
        
        faceOut.color = Color.Lerp(faceOut.color, Color.black, fadeTime * Time.fixedDeltaTime);
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("DeathScene");
        
    }
}
