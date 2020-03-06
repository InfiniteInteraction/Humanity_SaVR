using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadHP : MonoBehaviour
{
    public TextMeshProUGUI hP;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       hP.text = "Health: " + GameObject.FindObjectOfType<Damage>().playerHealth.ToString();
    }
}
