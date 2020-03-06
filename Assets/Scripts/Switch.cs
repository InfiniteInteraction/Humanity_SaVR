using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    public float timer;
    public float currtime;
    void Awake()
    {
        timer = 3f;
        currtime = timer;
    }

    private void Update()
    {
        //currtime = (timer - Time.deltaTime);
        currtime -= (1 * Time.deltaTime);
        if (currtime <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }

}
