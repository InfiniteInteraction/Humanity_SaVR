using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject Panel;
    public bool isPaused;
    public void Start()
    {
        Panel.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }
    public void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            Paused();
        }
    }
    public void Paused()
    {
        isPaused = !isPaused;
        if (!isPaused)
        {
            Panel.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            Panel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
    public void Resume()
    {
        Panel.SetActive(false);
        isPaused = false;
        Time.timeScale = 1.0f;
    }
    //public void OnApplicationQuit()
    //{
    //#if UNITY_EDITOR
    //    UnityEditor.EditorApplication.isPlaying = false;
    //#else
    //    Application.Quit();
    //#endif
    //}
}
