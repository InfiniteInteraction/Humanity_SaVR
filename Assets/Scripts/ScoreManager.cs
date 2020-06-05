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
    public int currWave; //The index for the current level thwe player is on //Replace Scene Manager with Strings to call specific Wave 
    public int currScore; // The current score that is displayed to the player
    public TextMeshProUGUI hsText;
    public int[] _highScores;
    private int waveCount = 0;
    void Awake()
    {

        scoreManager = this;
        waveCount = GameManager.gameManager.waveNumber;
        currWave = ESpawner.eSpawner.waves;
        InitializeHighScores();
        Load();
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (hsText == null)
        {
            Debug.Log("No High Score");
        }
        else
        {
            hsText.text = "HighScore: " + _highScores[currWave].ToString();
        }
    }


    public void ResetCurrentScore()//Resets Current Score
    {
        currScore = 0;
    }
    public void InitializeHighScores()
    {
        _highScores = new int[scoreManager.waveCount];
        for (int i = 0; i < scoreManager.waveCount; ++i)
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

        data.scores = new int[scoreManager.waveCount];
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
        currWave = sceneIndex;
        if (currWave >= scoreManager.waveCount)
        {
            currWave = 0;
        }
       
    }
    public void LoadNextLevel()
    {
        int sceneIndex = ++currWave;
        if (currWave > scoreManager.waveCount)
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
        currWave = _currLvl.buildIndex;
        ResetCurrentScore();
    }
    public void CheckHighScore(int nextLevel)
    {
        if (currWave <= scoreManager.waveCount)
        {
            if (currWave != nextLevel)
            {
                if (_highScores[currWave] < currScore)
                {
                    _highScores[currWave] = currScore;
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