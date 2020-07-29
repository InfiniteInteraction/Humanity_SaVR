using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class HighScore_Table : MonoBehaviour
{
    public static HighScore_Table highScore_Table;
    
    private Transform entryContainer;
    public Transform entryTemplate;
    public int pScore;
    private List<Transform> highscoreEntryTransformList;

    private void Start() 
    {
        highScore_Table = this;
        entryContainer = transform.Find("HSEntryTempContainer");
        entryTemplate = entryContainer.Find("HSEntryTemp");
        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null) {
            // There's no stored table, initialize
           
            AddHighscoreEntry(22000, "BIL");
            AddHighscoreEntry(19000, "SER");
            AddHighscoreEntry(18000, "DON");
            AddHighscoreEntry(17000, "RHT");
            AddHighscoreEntry(16000, "RDS");
            AddHighscoreEntry(15000, "TJR");
            AddHighscoreEntry(14000, "JTR");
            AddHighscoreEntry(13000, "RVB");
            AddHighscoreEntry(12000, "TR");
            AddHighscoreEntry(10000, "JR");
            

            // Reload
            jsonString = PlayerPrefs.GetString("highscoreTable");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

        // Sort entry list by Score
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++) {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++) {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score) {
                    // Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList) 
    {
        float templateHeight = .45f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count -.2f);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank) {
        default:
            rankString = rank + "TH"; break;

        case 1: rankString = "1ST"; break;
        case 2: rankString = "2ND"; break;
        case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("WaveText").GetComponent<TextMeshProUGUI>().text = rankString;
        int score = highscoreEntry.score;
        

        entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().text = name;

        //// Set background visible odds and evens, easier to read
        //entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);
        
        // Highlight First
        if (rank == 1) {
            entryTransform.Find("WaveText").GetComponent<TextMeshProUGUI>().color = Color.blue;
            entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().color = Color.blue;
            entryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().color = Color.blue;
        }
        if (rank == 10)
        {
            transformList.RemoveAt(11);
        }


        transformList.Add(entryTransform);
    }

    public void AddHighscoreEntry(int score, string name) {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };
        
        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null) {
            // There's no stored table, initialize
            highscores = new Highscores() {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }

        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }

    /*
     * Represents a single High score entry
     * */
    [System.Serializable] 
    public class HighscoreEntry {
        public int score;
        public string name;
    }

}

