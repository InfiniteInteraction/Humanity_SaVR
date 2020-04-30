using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class NextLevel : MonoBehaviour
{
    Scene scene;
    public static NextLevel nLScript;
    public static bool gamePaused = false;

    
    public GameObject pausemenuUI;
    public GameObject soundSettings;

    public AudioMixer masterMixer;
    

    private void Awake()
    {
        nLScript = this;
        masterMixer = Resources.Load("AudioMixers/MasterMixer") as AudioMixer;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Pause();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    public void Back()
    {
        soundSettings.SetActive(false);
    }
    public void Resume()
    {
        
        CameraMovement.cMove.enabled = true;
        pausemenuUI.SetActive(false);
        soundSettings.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Pause()
    {
        
        CameraMovement.cMove.enabled = false;
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void SoundSettingMenu()
    {
        
        CameraMovement.cMove.enabled = false;
        soundSettings.SetActive(true);
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }
   
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
    public void Quit()
    {
        ScoreManager.scoreManager.Save();
        Time.timeScale = 1f;
        gamePaused = false;
        SceneManager.LoadScene(0);
    }

    public void SetMasterVolume(float volume)
    {
        masterMixer.SetFloat("masterVolume", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        masterMixer.SetFloat("sfxVolume", Mathf.Log10(volume) * 20);
    }

    public void SetMusicVolume(float volume)
    {
        masterMixer.SetFloat("musicVolume", Mathf.Log10(volume) * 20);
    }
}
