using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathFade : MonoBehaviour
{
    public Image fadeOut;
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
        FindObjectOfType<GunTestVR>().canShoot = false;
        fadeOut.color = Color.Lerp(fadeOut.color, Color.black, fadeTime * Time.deltaTime);
        GameObject.FindGameObjectWithTag("HUD").SetActive(false);
        //GameObject.FindGameObjectWithTag("MusicBox").SetActive(false);
        Audiomanager.audiomanager.Stop("SomewhereInGhana");
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("DeathScene");
        
    }
}
