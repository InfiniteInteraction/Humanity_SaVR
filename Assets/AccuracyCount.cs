using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AccuracyCount : MonoBehaviour
{
    public TextMeshProUGUI aC;

    void Awake()
    {
        //aC.text = GameManager.gameManager.accuracy.ToString();  
    }


    void Update()
    {
        aC.text = GameManager.gameManager.accuracy.ToString("F0")+  "%";
    }
}
