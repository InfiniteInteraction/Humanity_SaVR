using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Info : MonoBehaviour
{
    GunTest gtScript;
    GunTestVR gtScriptVR;
    string text, fireMode;
    TextMeshProUGUI myText;
    public int ammo, alienCount;
    float deltaTime = 0f;

    private void Awake()
    {
        if (FindObjectOfType<GunTest>())
        {
            gtScript = FindObjectOfType<GunTest>();
            gtScriptVR = null;
        }
        if (FindObjectOfType<GunTestVR>())
        {
            gtScriptVR = FindObjectOfType<GunTestVR>();
            gtScript = null;
        }
        myText = GetComponent<TextMeshProUGUI>();
        fireMode = " ";
        alienCount = 0;
    }

    private void FixedUpdate()
    {
        if (gtScript)
        {
            ammo = gtScript.currAmmo;
            if (gtScript.fullAutoMode)
                fireMode = "AUTO";
            else
                fireMode = "SINGLE";
        }
        if (gtScriptVR)
        {
            ammo = gtScriptVR.currAmmo;
            if (gtScriptVR.fullAutoMode)
                fireMode = "AUTO";
            else
                fireMode = "SINGLE";
        }

        deltaTime = Time.frameCount / Time.time;
        text = ("Ammo: " + ammo + "\n" + "Firing mode: " + fireMode + "\n" + "Alien Count: " + alienCount /*+ "\n" + "FPS: " + deltaTime*/);
        myText.text = text;
    }

}
