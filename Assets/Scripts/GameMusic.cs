using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public string musicName;

    
    void Start()
    {
        Audiomanager.audiomanager.Play(musicName);
    }


}
