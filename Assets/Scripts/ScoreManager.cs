using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    const float version = 1.1f;
    public static ScoreManager scoreManager;
    public static PlayerScore data = new PlayerScore(version);
    public int currLvl; //The index for the current level thwe player is on 
    public int currScore; // The current score that is displayed to the player
    public TextMeshProUGUI hsText;
    public int[] _highScores;
    private int sceneCount = 0;
    void Awake()
    {

        scoreManager = this;
        sceneCount = SceneManager.sceneCountInBuildSettings;
        currLvl = SceneManager.GetActiveScene().buildIndex;
        InitializeHighScores();
        Load();
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (hsText == null)
        {
            Debug.Log("No High Score");
        }
        else
        {
            hsText.text = "HighScore: " + _highScores[currLvl].ToString();
        }
    }


    public void ResetCurrentScore()//Resets Current Score
    {
        currScore = 0;
    }
    public void InitializeHighScores()
    {
        _highScores = new int[scoreManager.sceneCount];
        for (int i = 0; i < scoreManager.sceneCount; ++i)
        {
            _highScores[i] = 0;

        }
    }
    public void ResetAllHighScores()
    {
        for (int i = 0; i < _highScores.Length; ++i)
        {
            _highScores[i] = 0;
        }
    }
    public void ResetLvlHighScore(int level)
    {
        if (level < 0 || level > _highScores.Length)
        {
            return;
        }
        else
        {
            _highScores[level] = 0;
        }
    }
    public void IncreaseScore(int points)
    {
        currScore = currScore + points;
        if (currScore <= 0)
        {
            currScore = 0;
        }
    }
    public int GetHighScore(int level)
    {
        if (level < 0 || level > _highScores.Length)
        {
            return 0;
        }
        else
        {
            return _highScores[level];
        }
    }
    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/scores.game");

        data.scores = new int[scoreManager.sceneCount];
        data.scores = _highScores;

        formatter.Serialize(file, data);
        file.Close();
    }
    public bool Load()
    {
        if (File.Exists(Application.persistentDataPath + "/scores.game"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/scores.game", FileMode.Open);

            if (file.Length != 0)
            {
                PlayerScore loadedScores = (PlayerScore)formatter.Deserialize(file);
                if (loadedScores.GetVersion() == version)
                {
                    data = loadedScores;
                    if (loadedScores.scores != null)
                    {
                        _highScores = data.scores;

                    }
                }
                else
                {
                    File.Delete(Application.persistentDataPath + "/scores.game");
                    return false;
                }
            }
            file.Close();
            return true;
        }
        return false;
    }
    public void LoadLevel(int sceneIndex)
    {
        currLvl = sceneIndex;
        if (currLvl >= scoreManager.sceneCount)
        {
            currLvl = 0;
        }
        SceneManager.LoadScene(currLvl);
    }
    public void LoadNextLevel()
    {
        int sceneIndex = ++currLvl;
        if (currLvl > scoreManager.sceneCount)
        {
            LoadLevel(0);
        }
        else
        {
            LoadLevel(sceneIndex);
        }
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnSceneLoaded(Scene _currLvl, LoadSceneMode _mode)
    {
        CheckHighScore(_currLvl.buildIndex);
        Save();
        currLvl = _currLvl.buildIndex;
        ResetCurrentScore();
    }
    public void CheckHighScore(int nextLevel)
    {
        if (currLvl <= scoreManager.sceneCount)
        {
            if (currLvl != nextLevel)
            {
                if (_highScores[currLvl] < currScore)
                {
                    _highScores[currLvl] = currScore;
                }
            }
        }
    }
}
        [Serializable]
public class PlayerScore
{
    float version;
    public int[] scores;
    public PlayerScore(float _version) { version = _version; }
    public float GetVersion() { return version; }
}