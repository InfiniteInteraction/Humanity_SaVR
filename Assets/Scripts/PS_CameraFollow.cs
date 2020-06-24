using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
            Debug.Log("PS_CameraFollow script can find the player gameobject.");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = player.position;
            transform.rotation = player.rotation;
        }

    }
}
